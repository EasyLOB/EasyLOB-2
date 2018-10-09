using System;

namespace EasyLOB.Log
{
    public partial class LogManagerMock : ILogManager
    {
        #region Methods

        public virtual void Dispose()
        {
        }

        public void Trace(string message, params object[] args)
        {
        }

        public void Debug(string message, params object[] args)
        {
        }

        public void Info(string message, params object[] args)
        {
        }

        public void Warning(string message, params object[] args)
        {
        }

        public void Error(string message, params object[] args)
        {
        }

        public void Fatal(string message, params object[] args)
        {
        }

        public void Exception(Exception exception, string message)
        {
        }

        public void LogException(Exception exception)
        {
        }

        public void LogOperationResult(ZOperationResult operationResult)
        {
        }

        #endregion Methods
    }
}