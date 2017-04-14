using EasyLOB.Resources;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Runtime.Serialization;

// .NET WebAPI Serialization k_BackingField Nastiness
// http://stackoverflow.com/questions/12334382/net-webapi-serialization-k-backingfield-nastiness

namespace EasyLOB
{
    /// <summary>
    /// Z Operation Result
    /// </summary>
    [DataContract]
    [Serializable]
    public class ZOperationResult
    {
        #region Properties

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
        /// Operation Result Html.
        /// </summary>
        [DataMember]
        public string Html
        {
            get
            {
                string result = "";
                string br = "";

                string labelStatus = "<label class=\"label label-success\">{0}</label>";

                // Status Message

                if (!String.IsNullOrEmpty(StatusCode) || !String.IsNullOrEmpty(StatusMessage))
                {
                    string text =
                        (!String.IsNullOrEmpty(StatusCode) ? "[ " + StatusCode + " ] " : "") +
                        StatusMessage;
                    result += br + String.Format(labelStatus, text.Trim());
                    br = "<br />";
                }

                string labelError = "<label class=\"label label-danger\">{0}</label>";

                // Error Message

                if (!String.IsNullOrEmpty(ErrorCode) || !String.IsNullOrEmpty(ErrorMessage))
                {
                    string text =
                        ErrorResources.Error + ": " +
                        (!String.IsNullOrEmpty(ErrorCode) ? "[ " + ErrorCode + " ] " : "") +
                        ErrorMessage;
                    result += br + String.Format(labelError, text.Trim());
                    br = "<br />";
                }

                // Errors

                int button = 1;
                foreach (ZOperationError operationError in OperationErrors)
                {

                    string text =
                        ErrorResources.Error + ": " +
                        (!String.IsNullOrEmpty(operationError.ErrorCode) ? "[ " + operationError.ErrorCode + " ] " : "") +
                        operationError.ErrorMessage;
                    string members = operationError.ErrorMembers.Count == 0 ? "" : " (" + String.Join(",", operationError.ErrorMembers).Trim() + ")";
                    result += br + String.Format(labelError, text.Trim() + members);
                    br = "<br />";

                    if (!String.IsNullOrEmpty(operationError.ErrorStackTrace))
                    {
                        string buttonId = "button" + button++.ToString();
                        result += "&nbsp;" +
                            String.Format("<button data-toggle=\"collapse\" data-target=\"#{0}\">...</button>", buttonId) +
                            String.Format("<div id=\"{0}\" class=\"collapse\">", buttonId);

                        if (operationError.ErrorStackTrace.Contains(" at "))
                        {
                            result += operationError.ErrorStackTrace.Replace(" at ", "<br />at ");
                        }
                        else
                        {
                            result += operationError.ErrorStackTrace.Replace(" na ", "<br />na ");
                        }

                        result += "</div>";

                        br = "<br />";
                    }
                }

                // Data

                if (!String.IsNullOrEmpty(Data))
                {
                    string text = "[" + Data + "]";
                    result += br + String.Format(labelStatus, text.Trim());
                    br = "<br />";
                }

                return result;
                //return result + (String.IsNullOrEmpty(result) ? "" : "<br />");
            }
        }

        /// <summary>
        /// Successfull ?
        /// </summary>
        [DataMember]
        public bool Ok
        {
            get { return (String.IsNullOrEmpty(ErrorCode) && String.IsNullOrEmpty(ErrorMessage) && OperationErrors.Count == 0); }
        }

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
        //public List<IZOperationError> OperationErrors { get; }

        /// <summary>
        /// Operation Result text with "\n".
        /// </summary>
        [DataMember]
        public string Text
        {
            get
            {
                List<string> list = ToList();
                string result = String.Join("\n", list);

                return result;
                //return result + (String.IsNullOrEmpty(result) ? "" : "\n");
            }
        }

        #endregion Properties

        #region Methods

        public ZOperationResult()
        {
            ErrorCode = "";
            ErrorMessage = "";
            StatusCode = "";
            StatusMessage = "";
            OperationErrors = new List<ZOperationError>();
        }

        [JsonConstructor]
        public ZOperationResult(
            string data,
            string errorCode,
            string errorMessage,
            string html,
            bool ok,
            string statusCode,
            string statusMessage,
            List<ZOperationError> operationErrors,
            string text)
            : this()
        {
            Data = data;
            ErrorCode = errorCode;
            ErrorMessage = errorMessage;
            // Html
            // Ok
            StatusCode = statusCode;
            StatusMessage = statusMessage;
            OperationErrors = operationErrors ?? OperationErrors;
            // Text
        }

        /// <summary>
        /// Add Operation Error.
        /// </summary>
        /// <param name="errorCode">Error code</param>
        /// <param name="errorMessage">Error message</param>
        /// <param name="errorStackTrace">Error stack trace</param>
        public void AddOperationError(string errorCode, string errorMessage, string errorStackTrace = null)
        {
            OperationErrors.Add(new ZOperationError(errorCode, errorMessage, errorStackTrace));
        }

        /// <summary>
        /// Add Operation Error.
        /// </summary>
        /// <param name="errorCode">Error code</param>
        /// <param name="errorMessage">Error message</param>
        /// <param name="errorStackTrace">Error stack trace</param>
        /// <param name="members">Members</param>
        public void AddOperationError(string errorCode, string errorMessage, string errorStackTrace, List<string> members)
        {
            OperationErrors.Add(new ZOperationError(errorCode, errorMessage, errorStackTrace, members));
        }

        /// <summary>
        /// Clear.
        /// </summary>
        public void Clear()
        {
            StatusCode = "";
            StatusMessage = "";
            ErrorCode = "";
            ErrorMessage = "";
            OperationErrors.Clear();
        }

        /// <summary>
        /// Parse Exception.
        /// </summary>
        /// <param name="exception">Exception</param>
        public void ParseException(Exception exception)
        {
            AddOperationError("", exception.Message, exception.StackTrace);
            ParseInnerException(exception);
        }

        /// <summary>
        /// Parse Inner Exception.
        /// </summary>
        /// <param name="exception">Exception</param>
        private void ParseInnerException(Exception exception)
        {
            if (exception.InnerException != null)
            {
                AddOperationError("", exception.InnerException.Message);
                AddOperationError("STACK", exception.InnerException.StackTrace);
                ParseInnerException(exception.InnerException);
            }
        }

        /// <summary>
        /// Convert ZOperationResult to List[IZOperationMessage]
        /// </summary>
        /// <returns>List</returns>
        public List<ZOperationMessage> ToDataSet()
        {
            List<ZOperationMessage> result = new List<ZOperationMessage>();

            List<string> messages = ToList();
            foreach (string message in messages)
            {
                result.Add(new ZOperationMessage(message));
            }

            return result;
        }

        /// <summary>
        /// Convert ZOperationResult to List[string]
        /// </summary>
        /// <returns>List</returns>
        public List<string> ToList()
        {
            List<string> result = new List<string>();

            // Status Message

            if (!String.IsNullOrEmpty(StatusCode) || !String.IsNullOrEmpty(StatusMessage))
            {
                string text = ErrorResources.Status + ": " +
                    (!String.IsNullOrEmpty(StatusCode) ? "[ " + StatusCode + " ] " : "") +
                    StatusMessage;
                result.Add(text.Trim());
            }

            // Error Message

            if (!String.IsNullOrEmpty(ErrorCode) || !String.IsNullOrEmpty(ErrorMessage))
            {
                string text = ErrorResources.Error + ": " +
                    (!String.IsNullOrEmpty(ErrorCode) ? "[ " + ErrorCode + " ] " : "") +
                    ErrorMessage;
                result.Add(text.Trim());
            }

            // Errors

            foreach (ZOperationError operationError in OperationErrors)
            {
                string text = ErrorResources.Error + ": " +
                    (!String.IsNullOrEmpty(operationError.ErrorCode) ? "[ " + operationError.ErrorCode + " ] " : "") +
                    operationError.ErrorMessage;
                string members = operationError.ErrorMembers.Count == 0 ? "" : " (" + String.Join(",", operationError.ErrorMembers).Trim() + ")";
                result.Add(text.Trim() + members);

                if (!String.IsNullOrEmpty(operationError.ErrorStackTrace))
                {
                    if (operationError.ErrorStackTrace.Contains(" at "))
                    {
                        result.Add(operationError.ErrorStackTrace.Replace(" at ", "\r\nat "));
                    }
                    else
                    {
                        result.Add(operationError.ErrorStackTrace.Replace(" na ", "\r\nna "));
                    }
                }
            }

            return result;
        }

        #endregion Methods
    }
}