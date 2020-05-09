using System;
using System.Collections.Generic;
using System.Net.Http;
using MarketoApiLibrary.Http.Services;
using MarketoApiLibrary.Model;
using MarketoApiLibrary.Provider;
using static MarketoApiLibrary.Constants.OAuth;
using UriBuilder = MarketoApiLibrary.Http.Helper.UriBuilder;
using HttpClientFactory = MarketoApiLibrary.Http.Services.HttpClientFactory;

namespace MarketoApiLibrary.Http.Oauth
{

    public class OAuthTokenRepository : IOAuthTokenRepository
    {
        private const string Key = "oauth";
        private readonly IApiConfig _oauthConfig;
        private readonly IHttpClientFactory _httpClientFactory;

        public OAuthTokenRepository()
        {
            _oauthConfig = ConfigurationProvider.LoadConfig();
            _httpClientFactory = new HttpClientFactory();
        }

        public AuthenticationToken GetToken(OAuthParameters parameters, string refreshToken = null)
        {
            var serverUri = _oauthConfig.Host;
            var relativePath = _oauthConfig.AuthorizeRelativePath;
            var builder = UriBuilder.Init(serverUri, relativePath);

            foreach (var param in this.GetQueryString(parameters))
            {
                builder.QueryParam(param.Key, param.Value);
            }

            var uri = builder.Build();

            var httpMethod = GetHttpMethod();

            var request = new HttpRequestMessage()
            {
                Method = httpMethod,
                RequestUri = uri
            };

            return this.SendRequest(request);
        }

        private static HttpMethod GetHttpMethod()
        {
            return HttpMethod.Get;
        }

        private Dictionary<string, string> GetQueryString(OAuthParameters parameters)
        {
            var qs = new Dictionary<string, string>
            {
                { ClientId, parameters.ClientId },
                { ClientSecret, parameters.ClientSecret },
                { GrantType, parameters.GrantType }
            };

            return qs;
        }

        private AuthenticationToken SendRequest(HttpRequestMessage request)
        {
            var httpClient = this._httpClientFactory.GetHttpClient(request.RequestUri, Convert.ToInt32(this._oauthConfig.RequestTimeoutSeconds), OAuthTokenRepository.Key);

            var responseMessage = httpClient.SendAsync(request).Result;
            var tokenDto = responseMessage.Content.ReadAsAsync<OAuthToken>().Result;

            if (!responseMessage.IsSuccessStatusCode)
                throw new HttpRequestException(
                    $"[{responseMessage.StatusCode}] {responseMessage.RequestMessage.Method} \"{responseMessage.RequestMessage.RequestUri}\" {tokenDto}");

            return new AuthenticationToken(tokenDto.AccessToken, tokenDto.TokenType, tokenDto.ExpiresIn,
                tokenDto.Scope);
        }
    }
}
