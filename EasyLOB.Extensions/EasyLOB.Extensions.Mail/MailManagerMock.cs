using System;

namespace EasyLOB.Extensions.Mail
{
    public partial class MailManagerMock : IMailManager
    {
        #region Methods Interface

        public void Mail(string toAddress,
            string subject, string body, bool isHtml = false)
        {
        }

        public void Mail(string fromName, string toName, string toAddress,
            string subject, string body, bool isHtml = false, string[] fileAttachmentPaths = null)
        {
        }

        public void Mail(System.Net.Mail.MailMessage message)
        {
        }

        public void Mail(System.Net.Mail.MailMessage message,
            string host, int port, string userName, string password, bool defaultCredentials, bool enableSsl)
        {
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