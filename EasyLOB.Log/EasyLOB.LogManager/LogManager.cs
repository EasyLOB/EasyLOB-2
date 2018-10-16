using Newtonsoft.Json;
using NLog;
using System;

// NLog.config | NLog.xsd

// Off => Trace => Debug => Info => Warn => Error => Fatal

// 6 - Fatal
// 5 - Error
// 4 - Warn
// 3 - Info
// 2 - Debug
// 1 - Trace
// 0 - Off

namespace EasyLOB.Log
{
    public partial class LogManager : ILogManager
    {
        #region Properties

        public Logger Log { get; }

        #endregion Properties

        #region Methods

        public LogManager()
        {
            Log = NLog.LogManager.GetLogger("NLog");
        }

        public virtual void Dispose()
        {
        }

        public void Trace(string message, params object[] args)
        {
            if (LogHelper.IsLog)
            {
                Log.Trace(message, args);
            }
        }

        public void Debug(string message, params object[] args)
        {
            if (LogHelper.IsLog)
            {
                Log.Debug(message, args);
            }
        }

        public void Information(string message, params object[] args)
        {
            if (LogHelper.IsLog)
            {
                Log.Info(message, args);
            }
        }

        public void Warning(string message, params object[] args)
        {
            if (LogHelper.IsLog)
            {
                Log.Warn(message, args);
            }
        }

        public void Error(string message, params object[] args)
        {
            if (LogHelper.IsLog)
            {
                Log.Error(message, args);
            }
        }

        public void Fatal(string message, params object[] args)
        {
            if (LogHelper.IsLog)
            {
                Log.Fatal(message, args);
            }
        }

        public void Fatal(Exception exception, string message)
        {
            if (LogHelper.IsLog)
            {
                Log.Fatal(exception, message);
            }
        }

        public void Exception(Exception exception, string message, params object[] args)
        {
            if (LogHelper.IsLog)
            {
                Log.Fatal(exception, message, args);
            }
        }

        public void OperationResult(ZOperationResultLog operationResultLog)
        {
            if (!String.IsNullOrEmpty(operationResultLog.Log))
            {
                JsonSerializerSettings jsonSettings = new JsonSerializerSettings
                {
                    Formatting = Formatting.None,
                    ReferenceLoopHandling = ReferenceLoopHandling.Ignore
                };

                LogEventInfo logEventInfo = new LogEventInfo(LogLevel.Trace, Log.Name, operationResultLog.Log);
                if (operationResultLog.Exception != null)
                {
                    logEventInfo.Exception = operationResultLog.Exception;
                }
                logEventInfo.Level = !operationResultLog.Ok ? LogLevel.Fatal : LogLevel.Info;
                // data.OperationResultOk:False
                // data.OperationResultOk:True
                logEventInfo.Properties["X-ELMAHIO-SEARCH-OperationResultOk"] = operationResultLog.Ok.ToString();
                logEventInfo.Properties["OperationResult"] =
                    JsonConvert.SerializeObject(operationResultLog, jsonSettings);

                Log.Log(logEventInfo);
            }
        }
        /*
        public void OperationResult(ZOperationResultLog operationResultLog)
        {
            Fatal("{@OperationResult}", operationResultLog);
        }
        */
        /*
        public void OperationResult(ZOperationResultLog operationResultLog)
        {

            // Status Message

            if (!String.IsNullOrEmpty(operationResultLog.StatusCode) || !String.IsNullOrEmpty(operationResultLog.StatusMessage))
            {
                string text = ErrorResources.Status + " " +
                    (!String.IsNullOrEmpty(operationResultLog.StatusCode) ?
                        "[ " + operationResultLog.StatusCode + " ] " : "") + operationResultLog.StatusMessage;
                Information(text);
            }

            // Error Message

            if (!String.IsNullOrEmpty(operationResultLog.ErrorCode) || !String.IsNullOrEmpty(operationResultLog.ErrorMessage))
            {
                string text = ErrorResources.Error + " " +
                    (!String.IsNullOrEmpty(operationResultLog.ErrorCode) ?
                        "[ " + operationResultLog.ErrorCode + " ] " : "") + operationResultLog.ErrorMessage;
                Error(text);
            }

            // Errors

            foreach (ZOperationError operationError in operationResultLog.OperationErrors)
            {
                string text = ErrorResources.Error + " " +
                    (!String.IsNullOrEmpty(operationError.ErrorCode) ?
                        "[ " + operationError.ErrorCode + " ] " : "") + operationError.ErrorMessage;
                Error(text);
            }
        }
         */
        #endregion Methods
    }
}