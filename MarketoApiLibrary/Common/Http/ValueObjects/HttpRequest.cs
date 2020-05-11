using System;
using System.Net.Http;
using System.Net.Http.Headers;

namespace MarketoApiLibrary.Common.Http.ValueObjects
{
    public class HttpRequest
    {
        public Uri Uri { get; set; }

        public HttpMethod Method { get; set; }

        public AuthenticationHeaderValue Authentication { get; set; }

        public HttpContent Body { get; set; }

        public int? Timeout { get; set; }
    }
}
