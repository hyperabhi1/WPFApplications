using System;
using System.Net;

namespace ModelService
{
    public class ResponseEntity<T>
    {
        public StatusCode StatusCode { get; set; }
        public T Data { get; set; }
        public ErrorResponse Error { get; set; }
    }

}
