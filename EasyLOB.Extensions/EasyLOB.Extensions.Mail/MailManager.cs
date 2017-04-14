using EasyLOB.Resources;
using System;
using System.Configuration;
using System.Net.Configuration;
using System.Net.Mail;

/*
<system.net>
  <mailSettings>
    <smtp from="email@gmail.com">
      <network enableSsl="true" host="smtp.gmail.com" port="587" userName="email@gmail.com" password="password" defaultCredentials="false"/>
    </smtp>
  </mailSettings>
</system.net>
 */

/*
System.Configuration.Configuration configuration = null;
if (System.Web.HttpContext.Current != null)
{
    configuration = System.Web.Configuration.WebConfigurationManager.OpenWebConfiguration("~");
}
else
{
    configuration = System.Configuration.ConfigurationManager.OpenExeConfiguration(ConfigurationUserLevel.None);
}
MailSettingsSectionGroup mailSettings = configuration.GetSectionGroup("system.net/mailSettings") as MailSettingsSectionGroup;
 */

namespace EasyLOB.Extensions.Mail
{
    public partial class MailManager : IMailManager
    {
        #region Methods Interface

        public void Mail(string toAddress,
            string subject, string body, bool isHtml = false)
        {
            toAddress = toAddress ?? "";
            subject = subject ?? "";
            body = body ?? "";

            if (String.IsNullOrEmpty(toAddress))
            {
                throw new Exception(String.Format(ErrorResources.EMailInvalidTo, toAddress));
            }

            SmtpSection smtpSection = (SmtpSection)ConfigurationManager.GetSection("system.net/mailSettings/smtp");
            if (smtpSection != null)
            {
                if (String.IsNullOrEmpty(smtpSection.From))
                {
                    throw new Exception(String.Format(ErrorResources.EMailInvalidFrom, smtpSection.From));
                }

                MailMessage message = new MailMessage();

                message.From = new MailAddress(smtpSection.From);
                message.SubjectEncoding = System.Text.Encoding.UTF8;
                foreach (var address in toAddress.Split(new[] { ";" }, StringSplitOptions.RemoveEmptyEntries))
                {
                    message.To.Add(new MailAddress(address, ""));
                }
                message.Subject = subject;
                message.Body = body;
                message.BodyEncoding = System.Text.Encoding.UTF8;
                message.IsBodyHtml = isHtml;

                Mail(message);
            }
        }

        public void Mail(string fromName, string toName, string toAddress,
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

            SmtpSection smtpSection = (SmtpSection)ConfigurationManager.GetSection("system.net/mailSettings/smtp");
            if (smtpSection != null)
            {
                if (String.IsNullOrEmpty(smtpSection.From))
                {
                    throw new Exception(String.Format(ErrorResources.EMailInvalidFrom, smtpSection.From));
                }

                MailMessage message = new MailMessage();

                message.From = new MailAddress(smtpSection.From, fromName);
                foreach (var address in toAddress.Split(new[] { ";" }, StringSplitOptions.RemoveEmptyEntries))
                {
                    message.To.Add(new MailAddress(address, toName));
                }
                message.Subject = subject;
                message.SubjectEncoding = System.Text.Encoding.UTF8;
                message.Body = body;
                message.BodyEncoding = System.Text.Encoding.UTF8;
                message.IsBodyHtml = isHtml;

                if (fileAttachmentPaths != null)
                {
                    foreach (string fileAttachmentPath in fileAttachmentPaths)
                    {
                        Attachment attach = new Attachment(fileAttachmentPath);
                        message.Attachments.Add(attach);
                    }
                }

                string host = smtpSection.Network.Host;
                int port = smtpSection.Network.Port;
                string userName = smtpSection.Network.UserName;
                string password = smtpSection.Network.Password;
                bool defaultCredentials = smtpSection.Network.DefaultCredentials;
                bool enableSsl = smtpSection.Network.EnableSsl;

                Mail(message, host, port, userName, password, defaultCredentials, enableSsl);
            }
        }

        public void Mail(MailMessage message)
        {
            if (message != null)
            {
                SmtpSection smtpSection = (SmtpSection)ConfigurationManager.GetSection("system.net/mailSettings/smtp");
                if (smtpSection != null)
                {
                    SmtpClient smtp = new SmtpClient();
                    smtp.UseDefaultCredentials = smtpSection.Network.DefaultCredentials;
                    smtp.Credentials = new System.Net.NetworkCredential(smtpSection.Network.UserName, smtpSection.Network.Password);
                    smtp.EnableSsl = smtpSection.Network.EnableSsl;
                    smtp.Host = smtpSection.Network.Host;
                    smtp.Port = smtpSection.Network.Port;

                    smtp.Send(message);
                }
            }
        }

        public void Mail(MailMessage message,
            string host, int port, string userName, string password, bool defaultCredentials, bool enableSsl)
        {
            host = host ?? "";
            userName = userName ?? "";
            password = password ?? "";

            SmtpClient smtp = new SmtpClient();
            smtp.UseDefaultCredentials = defaultCredentials;
            smtp.Credentials = new System.Net.NetworkCredential(userName, password);
            smtp.EnableSsl = enableSsl;
            smtp.Host = host;
            smtp.Port = port;

            smtp.Send(message);
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