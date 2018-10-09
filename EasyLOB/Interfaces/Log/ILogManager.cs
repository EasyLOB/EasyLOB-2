using System;

namespace EasyLOB.Log
{
    public interface ILogManager : IDisposable
    {
        #region Methods

        void Trace(string message, params object[] args);

        void Debug(string message, params object[] args);

        void Info(string message, params object[] args);

        void Warning(string message, params object[] args);

        void Error(string message, params object[] args);

        void Fatal(string message, params object[] args);

        void Exception(Exception exception, string message);

        void LogException(Exception exception);

        void LogOperationResult(ZOperationResult operationResult);

        #endregion Methods
    }
}