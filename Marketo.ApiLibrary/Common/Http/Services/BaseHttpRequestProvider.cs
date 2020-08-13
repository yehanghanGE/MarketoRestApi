using Marketo.ApiLibrary.Common.Configuration;
using Marketo.ApiLibrary.Common.Http.Oauth;
using Marketo.ApiLibrary.Common.Http.ValueObjects;
using Marketo.ApiLibrary.Common.Model;
using System;
using System.Collections.Generic;
using System.Net.Http;
using System.Net.Http.Headers;
using UriBuilder = Marketo.ApiLibrary.Common.Http.Helper.UriBuilder;

namespace Marketo.ApiLibrary.Common.Http.Services
{
    public abstract class BaseHttpRequestProvider<T> : IHttpRequestProvider<T> where T : BaseRequest
    {
        private readonly IConfigurationProvider _configuration;
        private readonly IAuthenticationTokenProvider _authenticationTokenProvider;

        protected BaseHttpRequestProvider(IConfigurationProvider configuration, IAuthenticationTokenProvider authenticationTokenProvider)
        {
            this._configuration = configuration;
            _authenticationTokenProvider = authenticationTokenProvider;
        }

        public virtual HttpRequest GetRequest(T serviceProviderRequest)
        {
            var baseUri = this.GetMarketoBaseUri();
            var relativeUrl = this.GetRelativeUrl(serviceProviderRequest);

            var builder = UriBuilder.Init(baseUri.ToString(), relativeUrl);
            foreach (var param in this.GetQueryString(serviceProviderRequest))
            {
                builder.QueryParam(param.Key, param.Value);
            }

            var uri = builder.Build();
            var body = this.GetBody(serviceProviderRequest);
            var authHeader = this.GetAuthHeader(serviceProviderRequest);
            var httpMethod = this.GetHttpMethod();
            var timeout = this.GetTimeout(serviceProviderRequest);

            var request = new HttpRequest
            {
                Method = httpMethod,
                Uri = uri,
                Body = body,
                Authentication = authHeader,
                Timeout = timeout
            };

            return request;
        }

        protected virtual Uri GetMarketoBaseUri()
        {
            var marketoConfig = this._configuration.LoadConfig();
            return new Uri(new Uri(marketoConfig.Host), marketoConfig.RestRelativePath);
        }

        protected abstract string GetRelativeUrl(T request);

        protected virtual HttpContent GetBody(T request)
        {
            return null;
        }

        protected virtual Dictionary<string, string> GetQueryString(T request)
        {
            return new Dictionary<string, string>();
        }

        protected abstract HttpMethod GetHttpMethod();

        protected virtual AuthenticationHeaderValue GetAuthHeader(T request)
        {
            var token = request.AuthenticationToken ?? _authenticationTokenProvider.GetToken();

            var authHeader = new AuthenticationHeaderValue(token.TokenType, token.Token);
            return authHeader;
        }

        protected virtual int? GetTimeout(T request)
        {
            return null;
        }

    }
}
