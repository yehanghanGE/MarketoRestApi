using MarketoApiLibrary.Asset.SmartLists.Request;
using MarketoApiLibrary.Common.Configuration;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Net.Http;
using System.Net.Http.Headers;
using System.Text;
using System.Threading.Tasks;
using System.Web;
using HttpClientFactory = MarketoApiLibrary.Common.Http.Services.HttpClientFactory;
using HttpRequest = MarketoApiLibrary.Common.Http.ValueObjects.HttpRequest;
using UriBuilder = MarketoApiLibrary.Common.Http.Helper.UriBuilder;


namespace MarketoApiLibrary.Asset.SmartLists
{
    public static class SmartListsHttpProcessor
    {

        /// <summary>
        /// GET /rest/asset/v1/smartLists.json
        /// </summary>
        /// <param name="request"></param>
        /// <returns></returns>
        public static async Task<T> GetSmartList<T>(GetSmartListsRequest getSmartListsRequest)
        {
            #region GetRequest
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
            #endregion
            #region ExecuteRequest
            var response = ExecuteRequest(request);
            #endregion
            #region ReadResponse

            var result = response.Content.ReadAsAsync<T>().Result;
            return result;

            #endregion
        }

        private static HttpResponseMessage ExecuteRequest(HttpRequest request)
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

        /// <summary>
        /// GET /rest/asset/v1/smartList/{id}.json
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <param name="request"></param>
        /// <returns></returns>
        public static async Task<T> GetSmartListById<T>(GetSmartListByIdRequest request)
        {
            var qs = HttpUtility.ParseQueryString(string.Empty);
            qs.Add("access_token", request.Token);
            qs.Add("includeRules", request.IncludeRules.ToString());

            var url = request.Host + $"/rest/asset/v1/smartLists/{request.Id}.json" + qs;

            var client = new HttpClient();
            var response = await client.GetAsync(url);
            response.EnsureSuccessStatusCode();

            var content = await response.Content.ReadAsAsync<T>();
            return content;
        }
        /// <summary>
        /// GET /rest/asset/v1/smartList/byName.json
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <returns></returns>
        public static async Task<T> GetSmartListByName<T>(GetSmartListByNameRequest request)
        {
            var qs = HttpUtility.ParseQueryString(string.Empty);
            qs.Add("access_token", request.Token);
            qs.Add("name", request.Name);

            var url = request.Host + $"/rest/asset/v1/smartList/byName.json" + qs;

            var client = new HttpClient();
            var response = await client.GetAsync(url);
            response.EnsureSuccessStatusCode();

            var content = await response.Content.ReadAsAsync<T>();
            return content;
        }
        /// <summary>
        /// POST /rest/asset/v1/smartList/{id}/delete.json
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <param name="request"></param>
        /// <returns></returns>
        public static async Task<T> DeleteSmartList<T>(DeleteSmartListRequest request)
        {
            var qs = HttpUtility.ParseQueryString(string.Empty);
            qs.Add("access_token", request.Token);

            var url = request.Host + $"/rest/asset/v1/smartList/{request.Id}/delete.json?" + qs;
            var client = new HttpClient();
            var content = new StringContent("", Encoding.UTF8, "application/json");
            var response = await client.PostAsync(url, content);
            response.EnsureSuccessStatusCode();
            T result;
            try
            {
                result = await response.Content.ReadAsAsync<T>();
            }
            catch (Exception e)
            {
                Console.WriteLine(e);
                throw;
            }

            return result;
        }
        /// <summary>
        /// POST /rest/asset/v1/smartList/{id}/clone.json
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <param name="request"></param>
        /// <returns></returns>
        public static async Task<T> CloneSmartList<T>(CloneSmartListRequest request)
        {
            var qs = HttpUtility.ParseQueryString(string.Empty);
            qs.Add("access_token", request.Token);
            qs.Add("folder", JsonConvert.SerializeObject(request.Folder));
            qs.Add("name", request.Name);
            qs.Add("description", request.Description);

            var url = request.Host + $"/rest/asset/v1/smartList/{request.Id}/clone.json?" + qs;
            var client = new HttpClient();
            var content = new StringContent("", Encoding.UTF8, "application/json");

            var response = await client.PostAsync(url, content);
            response.EnsureSuccessStatusCode();
            T result;
            try
            {
                result = await response.Content.ReadAsAsync<T>();
            }
            catch (Exception e)
            {
                Console.WriteLine(e);
                throw;
            }

            return result;

        }
    }
}
