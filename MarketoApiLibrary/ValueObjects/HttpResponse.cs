using System.Net;
using System.Net.Http;

namespace MarketoApiLibrary.ValueObjects
{

    public class HttpResponse
    {
        public HttpStatusCode Code { get; set; }

        public bool IsSuccessCode { get; set; }

        public HttpContent Content { get; set; }
    }

}
