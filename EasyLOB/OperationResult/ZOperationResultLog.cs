using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Runtime.Serialization;

namespace EasyLOB
{
    /// <summary>
    /// Z Operation Result Log
    /// </summary>
    [DataContract]
    [Serializable]
    public class ZOperationResultLog
    {
        #region Properties

        /// <summary>
        /// Log.
        /// </summary>
        [DataMember]
        public string Log
        {
            get
            {
                string log =
                    (String.IsNullOrEmpty(TenantName) ? "" : TenantName + " - ") +
                    (String.IsNullOrEmpty(UserName) ? "" : UserName + " - ") +
                    "";

                if (!Ok)
                {
                    if (!String.IsNullOrWhiteSpace(ErrorMessage))
                    {
                        log += ErrorMessage;
                    }
                    else
                    {
                        if (OperationErrors.Count > 0)
                        {
                            log += OperationErrors[0].ErrorMessage;
                        }
                    }
                }
                else
                {
                    if (!String.IsNullOrWhiteSpace(StatusMessage))
                    {
                        log += StatusMessage;
                    }
                    else
                    {
                        if (OperationErrors.Count > 0)
                        {
                            log += OperationErrors[0].ErrorMessage;
                        }
                    }
                }

                return log;
            }
        }

        /// <summary>
        /// Url.
        /// </summary>
        [DataMember]
        public string Url { get; set; }

        /// <summary>
        /// User Name.
        /// </summary>
        [DataMember]
        public string UserName { get; set; }

        /// <summary>
        /// Tenant Name.
        /// </summary>
        [DataMember]
        public string TenantName { get; set; }

        /// <summary>
        /// Data.
        /// </summary>
        [DataMember]
        public string Data { get; set; }

        /// <summary>
        /// Error Code.
        /// </summary>
        [DataMember]
        public string ErrorCode { get; set; }

        /// <summary>
        /// Error Message.
        /// </summary>
        [DataMember]
        public string ErrorMessage { get; set; }

        /// <summary>
        /// Exception.
        /// </summary>
        //[DataMember]
        public Exception Exception { get; set; }

        /// <summary>
        /// Successfull ?
        /// </summary>
        [DataMember]
        public bool Ok { get; set; }

        /// <summary>
        /// Status Code.
        /// </summary>
        [DataMember]
        public string StatusCode { get; set; }

        /// <summary>
        /// Status Message.
        /// </summary>
        [DataMember]
        public string StatusMessage { get; set; }

        /// <summary>
        /// Operation Errors.
        /// </summary>
        [DataMember]
        public List<ZOperationError> OperationErrors { get; }

        /// <summary>
        /// Operation Status.
        /// </summary>
        [DataMember]
        public List<ZOperationStatus> OperationStatuses { get; }

        #endregion Properties

        #region Methods

        public ZOperationResultLog()
        {
            Url = "";
            UserName = "";
            TenantName = "";
            ErrorCode = "";
            ErrorMessage = "";
            StatusCode = "";
            StatusMessage = "";
            OperationErrors = new List<ZOperationError>();
            OperationStatuses = new List<ZOperationStatus>();
        }

        [JsonConstructor]
        public ZOperationResultLog(
            string log,
            string url,
            string userName,
            string tenantName,
            string data,
            string errorCode,
            string errorMessage,
            Exception exception,
            string statusCode,
            string statusMessage,
            List<ZOperationError> operationErrors,
            List<ZOperationStatus> operationStatuses)
            : this()
        {
            // Log
            Url = url ?? "";
            UserName = userName ?? "";
            TenantName = tenantName ?? "";
            Data = data;
            ErrorCode = errorCode ?? "";
            ErrorMessage = errorMessage ?? "";
            Exception = exception;
            StatusCode = statusCode ?? "";
            StatusMessage = statusMessage ?? "";
            OperationErrors = operationErrors ?? OperationErrors;
            OperationStatuses = operationStatuses ?? OperationStatuses;
        }

        public ZOperationResultLog(string url, string userName, string tenantName, ZOperationResult operationResult)
        {
            Url = url;
            UserName = userName;
            TenantName = tenantName;
            Data = operationResult.Data;
            ErrorCode = operationResult.ErrorCode;
            ErrorMessage = operationResult.ErrorMessage;
            Exception = operationResult.Exception;
            StatusCode = operationResult.StatusCode;
            StatusMessage = operationResult.StatusCode;
            OperationErrors = operationResult.OperationErrors;
            OperationStatuses = operationResult.OperationStatuses;
        }

        public string ToJson()
        {
            var settings = new JsonSerializerSettings
            {
                ReferenceLoopHandling = ReferenceLoopHandling.Ignore
            };

            return JsonConvert.SerializeObject(this, Formatting.Indented, settings);
        }

        #endregion Methods
    }
}