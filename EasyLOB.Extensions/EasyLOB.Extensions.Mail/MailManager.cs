using EasyLOB.Resources;
using MailKit.Net.Smtp;
using MailKit.Security;
using MimeKit;
using System;

namespace EasyLOB.Extensions.Mail
{
    public partial class MailManager : IMailManager
    {
        #region Properties

        public string FromAddress { get; set; }

        public string UserName { get; set; }

        public string Password { get; set; }

        #endregion Properties

        #region Methods

        public MailManager()
        {
            FromAddress = "";
            UserName = "";
            Password = "";
        }

        #endregion Methods

        #region Methods Interface

        public void Mail(string toAddress,
            string subject, string body, bool isHtml = false)
        {
            Mail("", "", toAddress,
                subject, body, isHtml);
        }

        public void Mail(string fromName,
            string toName, string toAddress,
            string subject, string body, bool isHtml = false, string[] fileAttachmentPaths = null)
        {
            fromName = fromName ?? "";
            toName = toName ?? "";
            toAddress = toAddress ?? "";
            subject = subject ?? "";
            body = body ?? "";

            if (String.IsNullOrEmpty(toAddress))
            {
                throw new Exception(String.Format(ErrorResources.EMailInvalidTo, toAddress));
            }

            string fromAddress;
            if (!String.IsNullOrEmpty(FromAddress))
            {
                fromAddress = FromAddress;
            }
            else
            {
                fromAddress = ConfigurationHelper.AppSettings<string>("Mail.FromAddress");
            }            
            if (String.IsNullOrEmpty(fromAddress))
            {
                throw new Exception(String.Format(ErrorResources.EMailInvalidFrom, fromAddress));
            }

            MimeMessage message = new MimeMessage();
            message.From.Add(new MailboxAddress(fromName, fromAddress));
            foreach (var address in toAddress.Split(new[] { ";" }, StringSplitOptions.RemoveEmptyEntries))
            {
                message.To.Add(new MailboxAddress(address));
            }
            message.Subject = subject;

            //if (isHtml)
            //{
            //    message.Body = new TextPart(TextFormat.Html)
            //    {
            //        Text = body
            //    };
            //}
            //else
            //{
            //    message.Body = new TextPart(TextFormat.Text)
            //    {
            //        Text = body
            //    };
            //}

            var builder = new BodyBuilder();

            if (isHtml)
            {
                builder.HtmlBody = body;
            }
            else
            {
                builder.TextBody = body;
            }

            if (fileAttachmentPaths != null)
            {
                foreach (string path in fileAttachmentPaths)
                {
                    builder.Attachments.Add(path);
                }
            }

            message.Body = builder.ToMessageBody();

            Mail(message);
        }

        public void Mail(MimeMessage message)
        {
            if (message != null)
            {
                string host = ConfigurationHelper.AppSettings<string>("Mail.Host");
                int port = ConfigurationHelper.AppSettings<int>("Mail.Port");
                string userName = ConfigurationHelper.AppSettings<string>("Mail.UserName");
                string password = ConfigurationHelper.AppSettings<string>("Mail.Password");
                bool ssl = ConfigurationHelper.AppSettings<bool>("Mail.SSL");

                Mail(message,
                    host, port, userName, password, ssl);
            }
        }

        public void Mail(MimeMessage message,
            string host, int port, string userName, string password, bool ssl)
        {
            host = host ?? "";
            userName = userName ?? "";
            password = password ?? "";

            if (!String.IsNullOrEmpty(UserName))
            {
                userName = UserName;
                password = Password;
            }

            // GMail
            // 465 = SSL
            // 587 = TLS
            // How do I access GMail using MailKit?
            // http://www.mimekit.net/docs/html/Frequently-Asked-Questions.htm#GMailAccess
            // Less Secure Accounts
            // https://myaccount.google.com/lesssecureapps
            // Office 365
            // POP and IMAP email settings for Outlook
            // https://support.office.com/en-us/article/pop-and-imap-email-settings-for-outlook-8361e398-8af4-4e97-b147-6c6c4ac95353
            SmtpClient smtp = new SmtpClient();
            //smtp.ServerCertificateValidationCallback = (s, c, h, e) => true;
            smtp.Connect(host, port, SecureSocketOptions.Auto);
            //smtp.Connect(host, port, ssl); // SSL
            //smtp.Connect(host, port, SecureSocketOptions.StartTls); // TLS
            smtp.Authenticate(userName, password);
            smtp.Send(message);
            smtp.Disconnect(true);
        }

        #endregion Methods Interface

        #region Methods IDispose

        private bool disposed = false;

        public void Dispose()
        {
            Dispose(true);
            GC.SuppressFinalize(this);
        }

        protected virtual void Dispose(bool disposing)
        {
            if (!disposed)
            {
                if (disposing)
                {
                }

                disposed = true;
            }
        }

        #endregion Methods IDispose
    }
}
