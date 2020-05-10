using MarketoApiLibrary.Common.Http.ValueObjects;
using MarketoApiLibrary.Common.Model;

namespace MarketoApiLibrary.Common.Http.Services
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
