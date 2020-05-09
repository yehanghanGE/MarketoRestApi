using MarketoApiLibrary.Model;
using MarketoApiLibrary.Provider;
using System;
using System.Net.Http;
using System.Net.Http.Headers;
using System.Text;
using System.Threading.Tasks;
using System.Web;

namespace MarketoApiLibrary
{
    public class ApiHelper : IApiHelper
    {
        private HttpClient _apiClient;
        private IApiConfig _apiConfig;
        public ApiHelper()
        {
            InitializeClient();
        }
        public HttpClient ApiClient
        {
            get
            {
                return _apiClient;
            }
        }

        private void InitializeClient()
        {
            _apiConfig = ConfigurationProvider.LoadConfig();
            _apiClient = new HttpClient { BaseAddress = new Uri(_apiConfig.Host) };
            _apiClient.DefaultRequestHeaders.Accept.Clear();
            _apiClient.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue("application/json"));
        }

        public async Task<IdentityResponse> Authenticate()
        {
            var qs = HttpUtility.ParseQueryString(string.Empty);
            qs.Add("grant_type", "client_credentials");
            qs.Add("client_id", _apiConfig.ClientId);
            qs.Add("client_secret", _apiConfig.ClientSecret);
            var url = new StringBuilder("/identity/oauth/token?");
            url.Append(qs);

            using (var response = await _apiClient.GetAsync(url.ToString()))
            {
                if (response.IsSuccessStatusCode)
                {
                    var result = await response.Content.ReadAsAsync<IdentityResponse>();
                    _apiClient.DefaultRequestHeaders.Add("Authorization", $"Bearer { result.AccessToken }");
                    return result;
                }
                else
                {
                    throw new Exception(response.ReasonPhrase);
                }
            }
        }
    }
}
