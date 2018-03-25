using System;
using System.Diagnostics.CodeAnalysis;
using System.IO;
using System.Net;
using System.Net.Mail;
using WebApplicationUtilities.Configuration;
using WebApplicationUtilities.Models;

namespace WebApplicationUtilities.Email
{
    [ExcludeFromCodeCoverage]
    public class Email : IEmail
    {
        private readonly EmailConfig _config;
        private MailMessage _mailMsg;
        private SmtpClient _smtpClient;

        public Email(IConfigManager configManager)
        {
            _config = configManager.GetFromSection<EmailConfig>("EmailConfig");
        }

        public void SendEmail(string message)
        {
            try
            {
                Init();

                _mailMsg.To.Add(_config.ToEmail);
                _mailMsg.Subject = "ApplicationServiceEmail";

                _mailMsg.Body = message;

                _smtpClient.Send(_mailMsg);

                _mailMsg.Dispose();
                _smtpClient.Dispose();
            }
            catch (Exception e)
            {
                ErrorProcess(e, message);
            }
        }

        public void SendEmail(Exception exception, string message)
        {
            try
            {
                Init();

                _mailMsg.To.Add(_config.ErrorEmailAddress);
                _mailMsg.Subject = "ApplicationServiceError";

                _mailMsg.Body = message +
                               Environment.NewLine +
                               exception.Message +
                               Environment.NewLine +
                               exception.StackTrace;

                _smtpClient.Send(_mailMsg);

                _mailMsg.Dispose();
                _smtpClient.Dispose();
            }
            catch (Exception)
            {
                ErrorProcess(exception, message);
            }
        }

        public void SendEmail(string subject, string message, string filePath)
        {
            try
            {
                Init();

                if (File.Exists(filePath))
                {
                    _mailMsg.To.Add(_config.ToEmail);
                    _mailMsg.Subject = subject;

                    var attachment = new Attachment(filePath);
                    _mailMsg.Attachments.Add(attachment);
                }
                else
                {
                    _mailMsg.To.Add(_config.ErrorEmailAddress);
                    _mailMsg.Subject = "IO Error";

                    _mailMsg.Body += Environment.NewLine + Path.GetFileName(filePath)
                                    + Environment.NewLine + "WAS NOT FOUND!!!";
                }

                _mailMsg.Body = message;

                _smtpClient.Send(_mailMsg);

                _mailMsg.Dispose();
                _smtpClient.Dispose();
            }
            catch (Exception e)
            {
                ErrorProcess(e, message);
            }
        }
        private void Init()
        {
            _mailMsg = new MailMessage();
            _smtpClient = new SmtpClient
            {
                Host = _config.SmtpHost,
                EnableSsl = _config.EnableSsl,
                Port = _config.SmtpPort,
                DeliveryMethod = SmtpDeliveryMethod.Network,
                Credentials = new NetworkCredential(_config.EmailAccount, _config.Credentials)
            };

            _mailMsg.From = new MailAddress(_config.EmailAccount);
            _mailMsg.IsBodyHtml = false;
        }

        private void ErrorProcess(Exception error, string message)
        {
            Init();

            _mailMsg.To.Add(_config.ErrorEmailAddress);
            _mailMsg.Subject = "ServiceEmailError";

            _mailMsg.Body = message +
                           Environment.NewLine +
                           error.Message +
                           Environment.NewLine +
                           error.StackTrace;

            _smtpClient.Send(_mailMsg);

            _mailMsg.Dispose();
            _smtpClient.Dispose();
        }
    }
}