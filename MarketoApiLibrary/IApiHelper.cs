using System.Net.Http;
using System.Threading.Tasks;

namespace MarketoApiLibrary
{
    public interface IApiHelper
    {
        HttpClient ApiClient { get; }

        Task<IdentityResponse> Authenticate();
    }
}