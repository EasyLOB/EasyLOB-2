using System;
using System.Web.Services.Protocols;

namespace EasyLOB.Library.WebService
{
    public static partial class ZOperationResultExtensions
    {
        public static void ParseExceptionWebService(this ZOperationResult operationResult, Exception exception)
        {
            if (exception is SoapException)
            {
                operationResult.ErrorMessage = exception.Message;
            }
            else
            {
                (operationResult as ZOperationResult).ParseException(exception);
            }
        }
    }
}