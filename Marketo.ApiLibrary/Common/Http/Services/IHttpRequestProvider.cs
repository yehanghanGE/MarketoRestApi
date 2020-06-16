using Marketo.ApiLibrary.Common.Http.ValueObjects;
using Marketo.ApiLibrary.Common.Model;

namespace Marketo.ApiLibrary.Common.Http.Services
{
    /// <summary>
    /// Provides methods for working with http
    /// </summary>
    public interface IHttpRequestProvider<in T> where T : BaseRequest
    {
        /// <summary>
        /// Get http request object
        /// </summary>
        /// <param name="serviceProviderRequest">Service provider request type</param>
        /// <returns></returns>
        HttpRequest GetRequest(T serviceProviderRequest);
    }
}
