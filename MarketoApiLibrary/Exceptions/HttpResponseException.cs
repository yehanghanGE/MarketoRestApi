using System;
using System.Net;
using System.Runtime.Serialization;

namespace MarketoApiLibrary.Exceptions
{
    public sealed class HttpResponseException : Exception
    {
        public HttpStatusCode Code { get; }

        public HttpResponseException(HttpStatusCode code) : base($"HTTP response returned error. Code: {code}.")
        {
            this.Code = code;
        }

        public HttpResponseException(HttpStatusCode code, string responseMessage) : base($"HTTP response returned error. Code: {code}. Response message: {responseMessage}")
        {
            this.Code = code;
        }

        private HttpResponseException(SerializationInfo info, StreamingContext context) : base(info, context)
        {
        }
    }
}
