using Newtonsoft.Json;
using RestSharp;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace MarketoRestApiLibrary.Provider
{
    public static class TokenProvider
    {
        /// <summary>
        /// Implemented using HttpWebRequest
        /// </summary>
        /// <param name="host"></param>
        /// <param name="clientId"></param>
        /// <param name="clientSecret"></param>
        /// <returns></returns>
        public static string GetToken(string host, string clientId, string clientSecret)
        {
            string url = host + "/identity/oauth/token?grant_type=client_credentials&client_id=" + clientId + "&client_secret=" + clientSecret;
            HttpWebRequest request = (HttpWebRequest)WebRequest.Create(url);
            request.ContentType = "application/json";
            HttpWebResponse response = (HttpWebResponse)request.GetResponse();
            Stream resStream = response.GetResponseStream();
            StreamReader reader = new StreamReader(resStream);
            String json = reader.ReadToEnd();
            Dictionary<String, String> dict = JsonConvert.DeserializeObject<Dictionary<String, String>>(json);
            return dict["access_token"];
        }

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
            HttpResponseMessage response = await client.GetAsync(url);
            string content = null;
            Dictionary<string, string> dict = new Dictionary<string, string>();
            if (response.IsSuccessStatusCode)
            {
                content = await response.Content.ReadAsStringAsync();
                dict = JsonConvert.DeserializeObject<Dictionary<string, string>>(content);
            }
            return dict["access_token"];
        }
        /// <summary>
        /// Implemented usiong restsharp
        /// </summary>
        /// <param name="host"></param>
        /// <param name="clientId"></param>
        /// <param name="clientSecret"></param>
        /// <returns></returns>
        public static async Task<string> GetTokenAsync2(string host, string clientId, string clientSecret)
        {
            var client = new RestClient(host);
            string endpoint = "/identity/oauth/token?grant_type=client_credentials&client_id=" + clientId + "&client_secret=" + clientSecret;
            var request = new RestRequest(endpoint, DataFormat.Json);
            var result = await client.GetAsync<Dictionary<string, string>>(request);
            return result["access_token"];
        }
    }
}
