using System;
using System.Net;
using System.Net.Http;
using System.Threading.Tasks;
using ModelService;

namespace UtilityService
{
    public class Internet
    {
        private static readonly HttpClient HttpClient = new HttpClient();
        private static bool _hasInternetAccess = false;
        static Internet()
        {
            HttpClient.Timeout = TimeSpan.FromSeconds(3);
        }
        /// <summary>
        /// Check if System has internet access 
        /// </summary>
        /// <param name="address">default: https://www.google.com </param>
        /// <returns>True if connected to VPN</returns>
        public static async Task<ResponseEntity<bool>> IsInternetConnected(string address = @"https://www.google.com")
        {
            try
            {
                HttpResponseMessage response = await HttpClient.GetAsync(new Uri(address));
                if(response.StatusCode == HttpStatusCode.OK)
                {
                    _hasInternetAccess = true;
                    return new ResponseEntity<bool>()
                    {
                        Data = true,
                        StatusCode = StatusCode.InternetConnected
                    };
                }
                else
                {
                    _hasInternetAccess = false;
                    return new ResponseEntity<bool>()
                    {
                        Data = false,
                        StatusCode = StatusCode.InternetNotConnected
                    };
                }
            }
            catch
            {
                _hasInternetAccess = false;
                return new ResponseEntity<bool>()
                {
                    Data = false,
                    StatusCode = StatusCode.InternetNotConnected
                };
            }
        }
        /// <summary>
        /// Check if Vpn is connected
        /// </summary>
        /// <param name="address">default: http://jobstestuser:KnanUCQJqVP5Mxl@solrqalb.livecareer.com:8983/solr/resumesv3/admin/ping </param>
        /// <returns>True if connected to VPN</returns>
        public static async Task<ResponseEntity<bool>> IsOfficeVpnConnected(string address = @"http://jobstestuser:KnanUCQJqVP5Mxl@solrqalb.livecareer.com:8983/solr/resumesv3/admin/ping")
        {
            if (_hasInternetAccess)
                try
                {
                    HttpResponseMessage response = await HttpClient.GetAsync(new Uri(address));
                    if (response.StatusCode == HttpStatusCode.OK)
                    {
                        return new ResponseEntity<bool>()
                        {
                            Data = true,
                            StatusCode = StatusCode.VpnConnected
                        };
                    }

                    return new ResponseEntity<bool>()
                    {
                        Data = false,
                        StatusCode = (StatusCode)Enum.Parse(typeof(StatusCode), response.StatusCode.ToString()),
                        Error = new ErrorResponse()
                        {
                            UiSafeMessage = "VPN Not Connected",
                            DeveloperMessage = "VPN Not Connected",
                            ErrorCode = StatusCode.Error.ToString()
                        }
                    };
                }
                catch (Exception e)
                {
                    return new ResponseEntity<bool>()
                    {
                        Data = false,
                        StatusCode = StatusCode.VpnNotConnected,
                        Error = new ErrorResponse()
                        {
                            UiSafeMessage = "VPN Not Connected",
                            DeveloperMessage = e.Message,
                            ExceptionStackTrace = e.StackTrace,
                            ExceptionMessage = e.Message,
                            InnerException = e.InnerException?.StackTrace,
                            InnerExceptionMessage = e.InnerException?.StackTrace,
                            ErrorCode = StatusCode.Error.ToString()
                        }
                    };
                }

            return new ResponseEntity<bool>()
            {
                Data = false,
                StatusCode = StatusCode.VpnNotConnected
            };
        }
    }
}
