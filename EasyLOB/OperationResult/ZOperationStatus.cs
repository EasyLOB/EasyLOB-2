using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Runtime.Serialization;

// .NET WebAPI Serialization k_BackingField Nastiness
// http://stackoverflow.com/questions/12334382/net-webapi-serialization-k-backingfield-nastiness

namespace EasyLOB
{
    /// <summary>
    /// Z Operation Status
    /// </summary>
    [Serializable]
    [DataContract]
    public class ZOperationStatus
    {
        #region Properties

        /// <summary>
        /// Status Code.
        /// </summary>
        [DataMember]
        public string StatusCode { get; }

        /// <summary>
        /// Status Message.
        /// </summary>
        [DataMember]
        public string StatusMessage { get; }

        [DataMember]
        public List<string> StatusMembers { get; }

        #endregion Properties

        #region Methods

        [JsonConstructor]
        public ZOperationStatus(string statusCode, string statusMessage, List<string> statusMembers = null)
        {
            StatusCode = statusCode ?? "";
            StatusMessage = statusMessage ?? "";
            StatusMembers = statusMembers ?? new List<string>();
        }

        #endregion Methods
    }
}