using System.Threading.Tasks;

namespace MarketoRestApiLibrary.Provider
{
    public interface ITokenProvider
    {
        Task<string> GetTokenAsync(string host, string clientId, string clientSecret);
    }
}