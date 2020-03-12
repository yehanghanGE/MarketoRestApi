using Newtonsoft.Json;
using System.Collections.Generic;
using System.Net.Http;
using System.Threading.Tasks;

namespace MarketoRestApiLibrary.Provider
{
    public static class TokenProvider
    {
        /// <summary>
        /// Implemented using HttpClient
        /// </summary>
        /// <param name="host"></param>
        /// <param name="clientId"></param>
        /// <param name="clientSecret"></param>
        /// <returns></returns>
        public static async Task<string> GetTokenAsync(string host, string clientId, string clientSecret)
        {
            string url = host + "/identity/oauth/token?grant_type=client_credentials&client_id=" + clientId + "&client_secret=" + clientSecret;

            var client = new HttpClient();
            var response = await client.GetAsync(url);
            response.EnsureSuccessStatusCode();

            string content = await response.Content.ReadAsStringAsync();
            var dict = JsonConvert.DeserializeObject<Dictionary<string, string>>(content);

            return dict["access_token"];
        }

    }
}
