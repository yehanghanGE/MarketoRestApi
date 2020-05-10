using System;
using System.Net.Http;
using System.Threading.Tasks;

namespace MarketoApiLibrary.Common.Http.Services
{
    /// <summary>
    /// 
    /// </summary>
    public interface IHttpClientWrapper: IDisposable
    {
        /// <summary>
        /// 
        /// </summary>
        TimeSpan TimeOut { get; }
        /// <summary>
        /// 
        /// </summary>
        /// <param name="uri"></param>
        /// <param name="content"></param>
        /// <returns></returns>
        Task<HttpResponseMessage> PostAsync(Uri uri, HttpContent content);
        /// <summary>
        /// 
        /// </summary>
        /// <param name="request"></param>
        /// <returns></returns>
        Task<HttpResponseMessage> SendAsync(HttpRequestMessage request);
    }
}