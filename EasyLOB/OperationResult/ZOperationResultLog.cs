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
            string url,
            string userName,
            string tenantName,
            string errorCode,
            string errorMessage,
            string statusCode,
            string statusMessage,
            List<ZOperationError> operationErrors,
            List<ZOperationStatus> operationStatuses)
            : this()
        {
            Url = url ?? "";
            UserName = userName ?? "";
            TenantName = tenantName ?? "";
            ErrorCode = errorCode ?? "";
            ErrorMessage = errorMessage ?? "";
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
            ErrorCode = operationResult.ErrorCode;
            ErrorMessage = operationResult.ErrorMessage;
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