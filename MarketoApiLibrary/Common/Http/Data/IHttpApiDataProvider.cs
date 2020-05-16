using MarketoApiLibrary.Common.Logging;
using System;
using MarketoApiLibrary.Common.Http.ValueObjects;

namespace MarketoApiLibrary.Common.Http.Data
{
    /// <summary>
    /// Provides methods for working with HTTP API services
    /// </summary>
    public interface IHttpApiDataProvider
    {
        /// <summary>
        /// Send a request to HTTP API
        /// </summary>
        /// <param name="request"></param>
        /// <param name="logger"></param>
        /// <param name="errorHandler"></param>
        /// <returns></returns>
        HttpResponse SendRequest(HttpRequest request, ILoggingService<ILogInstance> logger, Func<HttpResponse, HttpResponse> errorHandler = null);
    }
}