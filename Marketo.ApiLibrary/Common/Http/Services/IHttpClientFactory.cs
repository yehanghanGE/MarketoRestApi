using System;

namespace Marketo.ApiLibrary.Common.Http.Services
{
    /// <summary>
    /// Provides methods to get IHttpClientWrapper
    /// </summary>
    public interface IHttpClientFactory
    {
        /// <summary>
        /// Get IHttpClientWrapper instance
        /// </summary>
        /// <param name="uri"></param>
        /// <param name="key"></param>
        /// <returns></returns>
        IHttpClientWrapper GetHttpClient(Uri uri, string key = "default");
        /// <summary>
        /// Get IHttpClientWrapper instance with requested timeout value
        /// </summary>
        /// <param name="uri"></param>
        /// <param name="timeout"></param>
        /// <param name="key"></param>
        /// <returns></returns>
        IHttpClientWrapper GetHttpClient(Uri uri, int timeout, string key = "default");
    }
}