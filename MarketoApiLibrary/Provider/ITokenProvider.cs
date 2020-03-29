using System.Threading.Tasks;

namespace MarketoApiLibrary.Provider
{
    public interface ITokenProvider
    {
        Task<string> GetTokenAsync(string host, string clientId, string clientSecret);
    }
}