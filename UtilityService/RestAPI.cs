using System;
using System.Collections.Generic;
using System.Net;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;
using ModelService;

namespace UtilityService
{
    public class RestApi
    {
        private static readonly HttpClient HttpClient = new HttpClient();
        private static WebClient webClient = new WebClient();


        public static async Task<ResponseEntity<string>> HttpGetAsync(string address)
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
            else
            {
                HttpResponseMessage response = await HttpClient.GetAsync(new Uri(address));
                if (response.StatusCode == HttpStatusCode.OK)
                {
                    return new ResponseEntity<string>()
                    {
                        Data = (await response.Content.ReadAsStringAsync()),
                        StatusCode = StatusCode.OK
                    };
                }
                else
                {
                    var statusCode = (StatusCode)Enum.Parse(typeof(StatusCode), response.StatusCode.ToString());
                    var content = await response.Content.ReadAsStringAsync();
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
        public static async Task<ResponseEntity<string>> HttpGetAsync(string url, string userId, string password)
        {
            return new ResponseEntity<string>();
        }
        public static async Task<ResponseEntity<string>> HttpGetAsync(string url, string authorizationToken)
        {
            return new ResponseEntity<string>();
        }
        public static async Task<ResponseEntity<string>> HttpPostAsync(string url, object payload)
        {
            return new ResponseEntity<string>();
        }
        public static async Task<ResponseEntity<string>> HttpPostAsync(string url, object payload, string userId, string password)
        {
            return new ResponseEntity<string>();
        }
        public static async Task<ResponseEntity<string>> HttpPostAsync(string url, object payload, string authorizationToken)
        {
            return new ResponseEntity<string>();
        }
    }
}
