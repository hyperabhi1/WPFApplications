using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml;
using ModelService;
using NSpeedTest.Models;
using UtilityService;
using UtilityService.Models;

namespace ConsoleAppTest
{
    class Program
    {
        static void Main(string[] args)
        {
            #region Bold
            var clientSecret = Bold.GetClientSecretAsync(SourceAppCd.ATEST_PRD_A_COR).Result;
            var token = Bold.GetTokenAsync(SourceAppCd.ATEST_PRD_A_COR).Result;
            var bold1 = 0;
            #endregion

            
            #region RestApi
            //var restapi0 = RestApi.HttpGetAsync("https://sandbox-auth.livecareer.com/v1/secrets/ATEST_SND_A_COR",true, "https://sandbox-auth.livecareer.com/v1/secrets/ATEST_SND_A_COR").Result;
            //var restapi1 = 0;
            #endregion


            #region Mail Test
            var f = new UtilityService.Email();
            var ttttt =  f.SendEmail(new List<string>(){"standalone.abhishek@gmail.com"},"test subject","testing body",10000,new List<string>(){"standalone.abhishek@gmail.com","abhishek.singh1@bold.com"}, new List<string>() { "standalone.abhishek@gmail.com", "abhishek.singh1@bold.com" }, new List<string>() { @"D:\Projects\jobsfeedprocessingcore\master\Component\BOLD.JobsFeedProcessing.Process\GenerateStringHashProcess.cs" });
            #endregion
       }
    }
}
