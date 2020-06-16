using System.Net;
using System.Net.Http;

namespace Marketo.ApiLibrary.Common.Http.ValueObjects
{

    public class HttpResponse
    {
        public HttpStatusCode Code { get; set; }

        public bool IsSuccessCode { get; set; }

        public HttpContent Content { get; set; }
    }

}
