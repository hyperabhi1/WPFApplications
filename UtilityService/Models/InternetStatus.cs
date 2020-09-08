using System;
using System.Collections.Generic;
using System.Text;

namespace UtilityService.Models
{
    public class InternetStatus
    {
        public int Latency { get; set; }
        public double DownloadSpeed { get; set; }
        public double UploadSpeed { get; set; }
    }
}
