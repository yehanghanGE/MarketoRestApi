using System.Net.Http;
using System.Threading.Tasks;

namespace Marketo.ApiLibrary
{
    public interface IApiHelper
    {
        HttpClient ApiClient { get; }

        Task<IdentityResponse> Authenticate();
    }
}