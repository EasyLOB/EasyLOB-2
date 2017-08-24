using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Runtime.Serialization;

// .NET WebAPI Serialization k_BackingField Nastiness
// http://stackoverflow.com/questions/12334382/net-webapi-serialization-k-backingfield-nastiness

namespace EasyLOB
{
    /// <summary>
    /// Z Operation Error
    /// </summary>
    [Serializable]
    [DataContract]
    public class ZOperationError
    {
        #region Properties

        /// <summary>
        /// Error Code.
        /// </summary>
        [DataMember]
        public string ErrorCode { get; }

        /// <summary>
        /// Error Message.
        /// </summary>
        [DataMember]
        public string ErrorMessage { get; }

        /// <summary>
        /// Error Stack.
        /// </summary>
        [DataMember]
        public string ErrorStackTrace { get; }

        [DataMember]
        public List<string> ErrorMembers { get; }

        #endregion Properties

        #region Methods

        [JsonConstructor]
        public ZOperationError(string errorCode, string errorMessage, string errorStackTrace = null, List<string> errorMembers = null)
        {
            ErrorCode = errorCode ?? "";
            ErrorMessage = errorMessage ?? "";
            ErrorStackTrace = errorStackTrace ?? "";
            ErrorMembers = errorMembers ?? new List<string>();
        }

        #endregion Methods
    }
}