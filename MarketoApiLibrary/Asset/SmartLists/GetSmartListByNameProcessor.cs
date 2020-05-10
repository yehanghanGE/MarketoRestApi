using MarketoApiLibrary.Asset.SmartLists.Request;
using MarketoApiLibrary.Common.Configuration;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Net.Http;
using System.Net.Http.Headers;
using System.Threading.Tasks;
using HttpClientFactory = MarketoApiLibrary.Common.Http.Services.HttpClientFactory;
using HttpRequest = MarketoApiLibrary.Common.Http.ValueObjects.HttpRequest;
using UriBuilder = MarketoApiLibrary.Common.Http.Helper.UriBuilder;

namespace MarketoApiLibrary.Asset.SmartLists
{
    public class GetSmartListByNameProcessor
    {
        public async Task<T> GetSmartList<T>(GetSmartListsRequest getSmartListsRequest)
        {
            var request = GetRequest<T>(getSmartListsRequest);
            var response = ExecuteRequest(request);
            var result = ReadResponse<T>(response);
            return result;
        }

        private HttpRequest GetRequest<T>(GetSmartListsRequest getSmartListsRequest)
        {
            var baseUri = GetMarketoBaseUri();
            var relativeUrl = GetRelativeUrl();
            var builder = UriBuilder.Init(baseUri.ToString(), relativeUrl);
            foreach (var param in GetQueryString(getSmartListsRequest))
            {
                builder.QueryParam(param.Key, param.Value);
            }

            var uri = builder.Build();
            var body = GetBody(getSmartListsRequest);
            var authHeader = GetAuthHeader(getSmartListsRequest);
            var httpMethod = GetHttpMethod();
            var timeout = GetTimeout(getSmartListsRequest);

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

        private HttpResponseMessage ExecuteRequest(HttpRequest request)
        {
            var message = new HttpRequestMessage
            {
                Method = request.Method,
                Content = request.Body,
                RequestUri = request.Uri,
                Headers = { Authorization = request.Authentication }
            };

            var serializedRequest = SerializeRequest(message);

            return SendMessage(message, request.Timeout);
        }

        private T ReadResponse<T>(HttpResponseMessage response)
        {
            var result = response.Content.ReadAsAsync<T>().Result;
            return result;
        }

        private static HttpResponseMessage SendMessage(HttpRequestMessage message, int? requestTimeout)
        {
            var httpClientFactory = new HttpClientFactory();
            var httpClient = requestTimeout.HasValue
                ? httpClientFactory.GetHttpClient(message.RequestUri, requestTimeout.Value)
                : httpClientFactory.GetHttpClient(message.RequestUri);
            var task = httpClient.SendAsync(message);
            return task.Result;
        }

        private static string SerializeRequest(HttpRequestMessage requestMessage)
        {
            var requestPart = $"Method: {requestMessage.Method}, RequestUri: {requestMessage.RequestUri.AbsoluteUri}";
            var json = requestMessage.Content?.ReadAsStringAsync().Result ?? string.Empty;
            if (string.IsNullOrEmpty(json))
                return requestPart;

            return $"{requestPart}, Content: {json}";
        }

        private static int? GetTimeout(GetSmartListsRequest request)
        {
            return null;
        }

        private static HttpMethod GetHttpMethod()
        {
            return HttpMethod.Get;
        }

        private static AuthenticationHeaderValue GetAuthHeader(GetSmartListsRequest request)
        {
            var token = request.AuthenticationToken;
            if (token == null)
                throw new InvalidOperationException("Token is null");

            var authHeader = new AuthenticationHeaderValue(token?.TokenType, token?.Token);
            return authHeader;
        }

        private static HttpContent GetBody(GetSmartListsRequest request)
        {
            return null;
        }

        private static Dictionary<string, string> GetQueryString(GetSmartListsRequest request)
        {
            return new Dictionary<string, string>
            {
                { Constants.QueryParameters.Asset.SmartList.Keys.Folder, JsonConvert.SerializeObject(request.Folder)},
                { Constants.QueryParameters.Asset.SmartList.Keys.Offset, request.Offset.ToString()},
                { Constants.QueryParameters.Asset.SmartList.Keys.MaxReturn, request.MaxReturn.ToString()},
                { Constants.QueryParameters.Asset.SmartList.Keys.EarliestUpdatedAt, request.EarliestUpdatedAt},
                { Constants.QueryParameters.Asset.SmartList.Keys.LatestUpdatedAt, request.LatestUpdatedAt}
            };
        }

        private static string GetRelativeUrl()
        {
            return $"/{Constants.UrlSegments.Asset}/{Constants.UrlSegments.Version}/{Constants.UrlSegments.SmartLists}";
        }

        private static Uri GetMarketoBaseUri()
        {
            var marketoConfig = ConfigurationProvider.LoadConfig();
            return new Uri(new Uri(marketoConfig.Host), marketoConfig.RestRelativePath);
        }
    }
}
