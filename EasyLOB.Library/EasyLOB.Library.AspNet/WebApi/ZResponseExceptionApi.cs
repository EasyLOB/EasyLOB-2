using System.Net;
using System.Net.Http;
using System.Web.Http;

namespace EasyLOB.Library.AspNet
{
    public class ZResponseExceptionApi : HttpResponseException
    {
        #region Methods

        public ZResponseExceptionApi(HttpRequestMessage request, ZOperationResult operationResult)
            : base(request.CreateResponse<ZOperationResult>(HttpStatusCode.BadRequest, operationResult))
        {
        }

        #endregion Methods
    }
}