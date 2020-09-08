using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using NSpeedTest.Models;
using UtilityService;
using UtilityService.Models;

namespace ConsoleAppTest
{
    class Program
    {
        static void Main(string[] args)
 
       {
            var f = new UtilityService.Email();
            var ttttt =  f.SendEmail(new List<string>(){"standalone.abhishek@gmail.com"},"test subject","testing body",10000,new List<string>(){"standalone.abhishek@gmail.com","abhishek.singh1@bold.com"}, new List<string>() { "standalone.abhishek@gmail.com", "abhishek.singh1@bold.com" }, new List<string>() { @"D:\Projects\jobsfeedprocessingcore\master\Component\BOLD.JobsFeedProcessing.Process\GenerateStringHashProcess.cs" });
            var test = UtilityService.Hash.NewGuid(format:GuidFormat.N);
            //var t = test.TestServerLatency(new Server(){Url = "https://www.google.com/" });
            var tt = 0;
       }
    }
}
