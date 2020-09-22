using ModelService;
using System;
using System.Collections.Generic;
using System.Data;
using System.Net;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;
using Newtonsoft.Json.Linq;

namespace UtilityService
{
    public class Bold
    {
        private static readonly HttpClient HttpClient = new HttpClient();
        private static readonly string SandboxAuthUrl = "https://sandbox-auth.livecareer.com";
        private static readonly string ProductionAuthUrl = "https://auth.livecareer.com";
        private static string body = String.Empty;
        private static string tokenUrl = String.Empty;
        private static string authUrl = String.Empty;
        private static string GetAuthUrl(SourceAppCd sourceAppCd)
        {
            var authBaseUrl = (sourceAppCd == SourceAppCd.ATEST_PRD_A_COR) ? ProductionAuthUrl : SandboxAuthUrl;
            tokenUrl = $"{authBaseUrl}/oauth/token";
            authUrl = $"{authBaseUrl}/v1/secrets/{sourceAppCd}";
            return authUrl;
        }
        private static string GetBody(string sourceAppCd, string clientSecret)
        {
            return $"grant_type=client_credentials&client_id={sourceAppCd}&client_secret={clientSecret}&response_type=token";
        }
        public static async Task<ResponseEntity<string>> GetClientSecretAsync(SourceAppCd sourceCd)
        {
            if (!(await Internet.IsInternetConnected()).Data)
            {
                return new ResponseEntity<string>()
                {
                    StatusCode = StatusCode.InternetNotConnected,
                    Error = new ErrorResponse()
                    {
                        ErrorCode = StatusCode.InternetNotConnected.ToString(),
                        UiSafeMessage = "Internet Not Connected",
                        DeveloperMessage = "Internet Not Connected"
                    }
                };
            }
            else if (!(await Internet.IsOfficeVpnConnected(GetAuthUrl(sourceCd))).Data)
            {
                return new ResponseEntity<string>()
                {
                    StatusCode = StatusCode.VpnNotConnected,
                    Error = new ErrorResponse()
                    {
                        ErrorCode = StatusCode.VpnNotConnected.ToString(),
                        UiSafeMessage = "Office VPN Not Connected",
                        DeveloperMessage = "Office VPN Not Connected"
                    }
                };
            }
            else
            {
                HttpResponseMessage response = await HttpClient.GetAsync(new Uri(GetAuthUrl(sourceCd)));
                if (response.StatusCode == HttpStatusCode.OK)
                {
                    return new ResponseEntity<string>()
                    {
                        Data = (await response.Content.ReadAsStringAsync()).Replace("\"", ""),
                        StatusCode = StatusCode.OK
                    };
                }
                else
                {
                    var statusCode = (StatusCode)Enum.Parse(typeof(StatusCode), response.StatusCode.ToString());
                    var content = JObject.Parse((await response.Content.ReadAsStringAsync()))["Message"].ToString();
                    return new ResponseEntity<string>()
                    {
                        StatusCode = statusCode,
                        Error = new ErrorResponse()
                        {
                            ErrorCode = statusCode.ToString(),
                            DeveloperMessage = content,
                            UiSafeMessage = content
                        }
                    };
                }
            }
        }
        /// <summary>
        /// Get ClientSecret and Token separated with |
        /// </summary>
        /// <param name="sourceAppCd">sourceAppCd</param>
        /// <returns>Returns ClientSecret and Token</returns>
        public static async Task<ResponseEntity<string>> GetTokenAsync(SourceAppCd sourceAppCd)
        {
            var clientSecret = await GetClientSecretAsync(sourceAppCd);
            if (clientSecret.StatusCode != StatusCode.OK)
            {
                return clientSecret;
            }
            else
            {
                HttpResponseMessage response = await HttpClient.PostAsync(tokenUrl, new StringContent(GetBody(sourceAppCd.ToString(), clientSecret.Data), Encoding.UTF8, "text/plain"));
                var content = await response.Content.ReadAsStringAsync();
                if (response.StatusCode == HttpStatusCode.OK)
                {
                    JObject parsedJson = JObject.Parse(content);
                    var schema = (string)parsedJson["token_type"];
                    var token = (string)parsedJson["access_token"];
                    return new ResponseEntity<string>()
                    {
                        Data = $"{clientSecret.Data}|{schema} {token}",
                        StatusCode = StatusCode.OK
                    };
                }
                else
                {
                    var statusCode = (StatusCode)Enum.Parse(typeof(StatusCode), response.StatusCode.ToString());
                    return new ResponseEntity<string>()
                    {
                        StatusCode = statusCode,
                        Error = new ErrorResponse()
                        {
                            ErrorCode = statusCode.ToString(),
                            DeveloperMessage = content,
                            UiSafeMessage = content
                        }
                    };
                }
            }
        }
    }
}
