using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Diagnostics;
using System.Text;
using ModelService;

namespace UtilityService
{
    public class PowerShell
    {
        /// <summary>
        /// Executes the command
        /// </summary>
        /// <param name="fileName">Default: cmd.exe</param>
        /// <param name="argument">Default: ping http://www.google.com</param>
        /// <returns>Console Output</returns>
        public static ResponseEntity<string> ExecuteCommand(string fileName = "powershell.exe", string argument = "ping http://www.google.com")
        {
            // Start the child process.
            Process p = new Process
            {
                StartInfo =
                {
                    UseShellExecute = false,
                    RedirectStandardOutput = true,
                    FileName = fileName,
                    CreateNoWindow = true,
                    Arguments = argument,
                    WindowStyle = ProcessWindowStyle.Hidden
                }
            };
            // Redirect the output stream of the child process.
            p.Start();
            // Do not wait for the child process to exit before
            // reading to the end of its redirected stream.
            // p.WaitForExit();
            // Read the output stream first and then wait.
            string consoleOutput = p.StandardOutput.ReadToEnd();
            p.WaitForExit();
            p.Close();
            return new ResponseEntity<string>()
            {
                Data = consoleOutput,
                StatusCode = StatusCode.OK
            };
        }
    }
}
