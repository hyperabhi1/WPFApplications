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
            #region CommandLine

            //ThreadSupport.ExecuteWithTimeLimit(new TimeSpan(0, 0, 0, 2),
            //    () =>
            //    {
            //        CommandLine.ExecuteCommand("rasdial.exe",
            //            "\"backup-vpn\" \"abhishek.singh1@bold.com\" \"5nXhjv4j\"");
            //    });
            //var connectBackupVpn =  CommandLine.ExecuteCommand("rasdial.exe", "\"backup-vpn\" \"abhishek.singh1@bold.com\" \"5nXhjv4j\"");
            //var disconnectBackupVpn = CommandLine.ExecuteCommand("rasdial.exe", "\"backup-vpn\" /disconnect");
            //var connectBoldVpnAzure = CommandLine.ExecuteCommand("powershell.exe", "rasautou.exe -o -f \"C:\\Users\\abhishek.singh1\\AppData\\Roaming\\Microsoft\\Network\\Connections\\Pbk\\rasphone.pbk\" -e \"BOLD-VPN-AZURE\"");
            //var connectBoldVpnAzure1 = CommandLine.ExecuteCommand("cmd.exe", "powershell.exe rasautou.exe -o -f \"C:\\Users\\abhishek.singh1\\AppData\\Roaming\\Microsoft\\Network\\Connections\\Pbk\\rasphone.pbk\" -e \"BOLD-VPN-AZURE\"");
            //var connectBoldVpnAzure = PowerShell.ExecuteCommand("rasautou.exe", "-o -f \"C:\\Users\\abhishek.singh1\\AppData\\Roaming\\Microsoft\\Network\\Connections\\Pbk\\rasphone.pbk\" -e \"BOLD-VPN-AZURE\"");
            var disconnectBoldVpnAzure = PowerShell.ExecuteCommand("rasdial.exe", "\"BOLD-VPN-AZURE\" /disconnect");
            var x = 0;
            #endregion


            #region Bold
            var clientSecret = Bold.GetClientSecretAsync(SourceAppCd.ATEST_SND_A_COR).Result;
            var token = Bold.GetTokenAsync(SourceAppCd.ATEST_SND_A_COR).Result;
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
