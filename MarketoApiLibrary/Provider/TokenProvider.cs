using Newtonsoft.Json;
using System.Collections.Generic;
using System.Net.Http;
using System.Threading.Tasks;

namespace MarketoApiLibrary.Provider
{
    public class TokenProvider : ITokenProvider
    {
        /// <summary>
        /// Implemented using HttpClient
        /// </summary>
        /// <param name="host"></param>
        /// <param name="clientId"></param>
        /// <param name="clientSecret"></param>
        /// <returns></returns>
        public async Task<string> GetTokenAsync(string host, string clientId, string clientSecret)
        {
            string url = host + "/identity/oauth/token?grant_type=client_credentials&client_id=" + clientId + "&client_secret=" + clientSecret;

            HttpClient client = new HttpClient();
            HttpResponseMessage response = await client.GetAsync(url);
            response.EnsureSuccessStatusCode();

            var result = await response.Content.ReadAsAsync<IdentityResponse>();

            return result.AccessToken;
        }

    }
}
