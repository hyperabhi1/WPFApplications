using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Text;
using ModelService;

namespace UtilityService
{
    public class CommandLine
    {
        /// <summary>
        /// Executes the command
        /// </summary>
        /// <param name="batchFilePath">batchFilePath</param>
        /// <returns>Console Output</returns>
        public static ResponseEntity<string> ExecuteBatchCommand(string batchFilePath)
        {
            if (System.IO.File.Exists(batchFilePath))
            {
                // Start the child process.
                Process p = new Process
                {
                    StartInfo =
                    {
                        UseShellExecute = false,
                        RedirectStandardOutput = true,
                        FileName = batchFilePath,
                        CreateNoWindow = true,
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
                    StatusCode = StatusCode.OK,
                    Error = null
                };
            }
            else
            {
                return new ResponseEntity<string>()
                {
                    StatusCode = StatusCode.NotFound,
                    Error = new ErrorResponse()
                    {
                        DeveloperMessage = "Batch file not found at the specified location",
                        ErrorCode = StatusCode.NotFound.ToString(),
                        UiSafeMessage = "File Not Found"
                    }
                };
            }
        }
        /// <summary>
        /// Executes the command
        /// </summary>
        /// <param name="fileName">Default: cmd.exe</param>
        /// <param name="argument">Default: ping http://www.google.com</param>
        /// <returns>Console Output</returns>
        public static ResponseEntity<string> ExecuteCommand(string fileName = "cmd.exe", string argument = "ping http://www.google.com")
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
        /// <summary>
        /// Executes the command and show realtime results
        /// </summary>
        /// <param name="fileName">Default: cmd.exe</param>
        /// <param name="argument">Default: ping http://www.google.com</param>
        /// <returns>Returns Help Link</returns>
        public static ResponseEntity<string> ExecuteCommandRealTime(string fileName = "cmd.exe", string argument = "ping http://www.google.com")
        {
            //https://stackoverflow.com/a/12570809
            return new ResponseEntity<string>()
            {
                StatusCode = StatusCode.MethodNotImplemented,
                Error = new ErrorResponse()
                {
                    DeveloperMessage = "Method Not Implemented. Visit https://stackoverflow.com/a/12570809",
                    ErrorCode = StatusCode.MethodNotImplemented.ToString(),
                    UiSafeMessage = "Error. Visit https://stackoverflow.com/a/12570809"
                }
            };

        }
    }
}
