using System.Net;

namespace RestApiAutomation
{
    public class ResponseModel
    {
        public HttpStatusCode HttpStatusCode { get; set; }
        public object ResponseData { get; set; }
    }
}
