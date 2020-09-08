using System;
using System.Collections.Generic;
using System.Net;
using System.Net.Mail;
using ModelService;
using UtilityService;

namespace EmailService
{
    public class Email
    {
        private readonly string _smtpHost;
        private readonly int _smtpPort;
        private readonly string _srcUserId;
        private readonly string _srcUserName;
        private readonly string _srcPassword;
        /// <summary>
        /// Initialize SMTP settings
        /// </summary>
        /// <param name="smtpHost"></param>
        /// <param name="smtpPort"></param>
        /// <param name="srcUserName"></param>
        /// <param name="srcUserId"></param>
        /// <param name="srcPassword"></param>
        public Email(string smtpHost, int smtpPort, string srcUserName, string srcUserId, string srcPassword)
        {
            _smtpHost = smtpHost;
            _smtpPort = smtpPort;
            _srcUserId = srcUserId;
            _srcPassword = srcPassword;
            _srcUserName = srcUserName;
        }
        /// <summary>
        /// defaults : Host = "smtp.gmail.com"; Port = 587; UserId = "iamemailsender@gmail.com"; Password = "test@123456789";
        /// </summary>
        public Email()
        {
            _smtpHost = "smtp.gmail.com";
            _smtpPort = 587;
            _srcUserId = "iamemailsender@gmail.com";
            _srcPassword = "test@123456789";
        }
        /// <summary>
        /// Sends mail to the recipients
        /// </summary>
        /// <param name="recipients">recipients list</param>
        /// <param name="subject">mail subject</param>
        /// <param name="body">mail body</param>
        /// <param name="timeout">timeout in ms</param>
        /// <param name="ccList">cc list</param>
        /// <param name="bccList">bcc list</param>
        /// <param name="attachmentsList">list of path full of attachments</param>
        /// <returns>ResponseEntity</returns>
        public ResponseEntity<StatusCode> SendEmail(List<string> recipients, string subject, string body, int timeout, List<string> ccList = null, List<string> bccList = null, List<string> attachmentsList = null)
        {
            if(Internet.IsInternetConnected())
                try
                {
                    MailMessage mailMessage = new MailMessage
                    {
                        From = new MailAddress(_srcUserId),
                        Subject = subject,
                        IsBodyHtml = true,
                        Body = body
                    };

                    mailMessage.Headers.Add("Machine-Name",Environment.MachineName);
                    mailMessage.Headers.Add("Machine-UserId",Environment.UserName);
                    mailMessage.Headers.Add("OS-Version", Environment.OSVersion.VersionString);
                    mailMessage.Headers.Add("time", DateTime.UtcNow.ToString("yyyy-MMM-dd HH:mm:ss.fff"));

                    recipients.ForEach(x => mailMessage.To.Add(new MailAddress(x)));
                    attachmentsList?.ForEach(x => mailMessage.Attachments.Add(new Attachment(x)));
                    ccList?.ForEach(x=>mailMessage.CC.Add(x));
                    bccList?.ForEach(x=>mailMessage.Bcc.Add(x));
                    SmtpClient smtp = new SmtpClient {Host = _smtpHost, EnableSsl = true};
                    NetworkCredential networkCred = new NetworkCredential { UserName = _srcUserName, Password = _srcPassword };
                    smtp.UseDefaultCredentials = true;
                    smtp.Credentials = networkCred;
                    smtp.Port = _smtpPort;
                    smtp.Send(mailMessage);
                    smtp.Timeout = timeout;

                    return new ResponseEntity<StatusCode>()
                    {
                        StatusCode = StatusCode.SENT,
                        Data = StatusCode.SENT
                    };
                }
                catch (SmtpException e)
                {
                    var errorResponse = new ErrorResponse()
                    {
                        UiSafeMessage = "Unable to send mail please check developer message",
                        DeveloperMessage = e.Message,
                        ExceptionStackTrace = e.StackTrace,
                        ExceptionMessage = e.Message,
                        InnerException = e.InnerException?.StackTrace,
                        InnerExceptionMessage = e.InnerException?.StackTrace,
                        ErrorCode = StatusCode.ERROR.ToString()
                    };
                    return new ResponseEntity<StatusCode>()
                    {
                        StatusCode = StatusCode.ERROR,
                        Error = errorResponse
                    };
                }
            else
            {
                var errorResponse = new ErrorResponse()
                {
                    UiSafeMessage = "No Internet Access",
                    DeveloperMessage = "Check Internet connectivity",
                    ErrorCode = StatusCode.NOINTERNETACCESS.ToString()
                };
                return new ResponseEntity<StatusCode>()
                {
                    StatusCode = StatusCode.ERROR,
                    Error = errorResponse
                };
            }
        }
    }
}
