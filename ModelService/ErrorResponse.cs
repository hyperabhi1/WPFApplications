using System;
using System.Collections.Generic;
using System.Text;

namespace ModelService
{
    public class ErrorResponse
    {
        public string ErrorCode { get; set; }
        public string DeveloperMessage { get; set; }
        public string UiSafeMessage { get; set; }
        public string ExceptionStackTrace { get; set; }
        public string ExceptionMessage { get; set; }
        public string InnerException { get; set; }
        public string InnerExceptionMessage { get; set; }
    }

}
