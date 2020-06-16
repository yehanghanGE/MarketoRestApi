using Marketo.ApiLibrary.Common.Logging;
using System;
using Marketo.ApiLibrary.Common.Http.ValueObjects;

namespace Marketo.ApiLibrary.Common.Http.Data
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