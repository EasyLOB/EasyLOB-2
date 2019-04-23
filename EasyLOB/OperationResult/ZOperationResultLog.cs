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
        /// Successfull ?
        /// </summary>
        [DataMember]
        public bool Ok { get; set; }

        /// <summary>
        /// Error ?
        /// </summary>
        [DataMember]
        public bool Error { get; set; }

        /// <summary>
        /// Warning ?
        /// </summary>
        [DataMember]
        public bool Warning { get; set; }

        /// <summary>
        /// Error ?
        /// </summary>
        [DataMember]
        public bool Information { get; set; }

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

                    if (!String.IsNullOrWhiteSpace(WarningMessage))
                    {
                        log += WarningMessage;
                    }
                    else
                    {
                        if (OperationWarnings.Count > 0)
                        {
                            log += OperationWarnings[0].WarningMessage;
                        }
                    }
                }
                else
                {
                    if (!String.IsNullOrWhiteSpace(InformationMessage))
                    {
                        log += InformationMessage;
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
        /// Tenant Name.
        /// </summary>
        [DataMember]
        public string TenantName { get; set; }

        /// <summary>
        /// User Name.
        /// </summary>
        [DataMember]
        public string UserName { get; set; }

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
        public Exception ErrorException { get; set; }

        /// <summary>
        /// Information Code.
        /// </summary>
        [DataMember]
        public string InformationCode { get; set; }

        /// <summary>
        /// Information Message.
        /// </summary>
        [DataMember]
        public string InformationMessage { get; set; }

        /// <summary>
        /// Text.
        /// </summary>
        public string Text { get; set; }

        /// <summary>
        /// Warning Code.
        /// </summary>
        [DataMember]
        public string WarningCode { get; set; }

        /// <summary>
        /// Warning Message.
        /// </summary>
        [DataMember]
        public string WarningMessage { get; set; }

        /// <summary>
        /// Operation Errors.
        /// </summary>
        [DataMember]
        public List<ZOperationError> OperationErrors { get; }

        /// <summary>
        /// Operation Information.
        /// </summary>
        [DataMember]
        public List<ZOperationInformation> OperationInformations { get; }

        /// <summary>
        /// Operation Warnings.
        /// </summary>
        [DataMember]
        public List<ZOperationWarning> OperationWarnings { get; }

        #endregion Properties

        #region Methods

        public ZOperationResultLog()
        {
            // Ok
            // Error
            // Warning
            // Information
            // Log
            Url = "";
            TenantName = "";
            UserName = "";
            ErrorCode = "";
            ErrorMessage = "";
            InformationCode = "";
            InformationMessage = "";
            Text = "";
            WarningCode = "";
            WarningMessage = "";
            OperationErrors = new List<ZOperationError>();
            OperationInformations = new List<ZOperationInformation>();
            OperationWarnings = new List<ZOperationWarning>();
        }

        [JsonConstructor]
        public ZOperationResultLog(
            bool ok,
            bool error,
            bool warning,
            bool information,            
            string url,
            string tenantName,
            string userName,
            string data,
            string errorCode,
            string errorMessage,
            Exception errorException,
            string informationCode,
            string informationMessage,
            string text,
            string warningCode,
            string warningMessage,
            List<ZOperationError> operationErrors,
            List<ZOperationInformation> operationInformations,
            List<ZOperationWarning> operationWarnings)
            : this()
        {
            Ok = ok;
            Error = error;
            Warning = warning;
            Information = information;
            // Log
            Url = url ?? "";
            TenantName = tenantName ?? "";
            UserName = userName ?? "";
            Data = data;
            ErrorCode = errorCode ?? "";
            ErrorMessage = errorMessage ?? "";
            ErrorException = errorException;
            InformationCode = informationCode ?? "";
            InformationMessage = informationMessage ?? "";
            Text = text;
            WarningCode = warningCode ?? "";
            WarningMessage = warningMessage ?? "";
            OperationErrors = operationErrors ?? OperationErrors;
            OperationInformations = operationInformations ?? OperationInformations;
            OperationWarnings = operationWarnings ?? OperationWarnings;
        }

        public ZOperationResultLog(string url, string tenantName, string userName, ZOperationResult operationResult)
        {
            Ok = operationResult.Ok;
            Error = operationResult.Error;
            Warning = operationResult.Warning;
            Information = operationResult.Information;
            // Log
            Url = url;
            TenantName = tenantName;
            UserName = userName;
            Data = operationResult.Data;
            ErrorCode = operationResult.ErrorCode;
            ErrorMessage = operationResult.ErrorMessage;
            ErrorException = operationResult.ErrorException;
            InformationCode = operationResult.InformationCode;
            InformationMessage = operationResult.InformationMessage;
            Text = operationResult.Text;
            WarningCode = operationResult.WarningCode;
            WarningMessage = operationResult.WarningMessage;
            OperationErrors = operationResult.OperationErrors;
            OperationInformations = operationResult.OperationInformations;
            OperationWarnings = operationResult.OperationWarnings;
        }

        #endregion Methods
    }
}