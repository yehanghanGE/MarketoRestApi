using MarketoApiLibrary.Asset.SmartLists.Request;
using Newtonsoft.Json;
using System;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;
using System.Web;

namespace MarketoApiLibrary.Asset.SmartLists
{
    public static class SmartListsHttpProcessor
    {
        /// <summary>
        /// GET /rest/asset/v1/smartLists.json
        /// </summary>
        /// <param name="request"></param>
        /// <returns></returns>
        public static async Task<T> GetSmartList<T>(GetSmartListsRequest request)
        {
            var qs = HttpUtility.ParseQueryString(string.Empty);
            qs.Add("access_token", request.Token);
            if (request.Folder != null)
            {
                qs.Add("folder", JsonConvert.SerializeObject(request.Folder));
            }
            if (request.Offset > 0)
            {
                qs.Add("offset", request.Offset.ToString());
            }
            if (request.MaxReturn > 0)
            {
                qs.Add("maxReturn", request.MaxReturn.ToString());
            }
            if (!string.IsNullOrEmpty(request.EarliestUpdatedAt))
            {
                qs.Add("earliestUpdatedAt", request.EarliestUpdatedAt);
            }
            if (!string.IsNullOrEmpty(request.LatestUpdatedAt))
            {
                qs.Add("latestUpdatedAt", request.LatestUpdatedAt);
            }
            var url = request.Host + "/rest/asset/v1/smartLists.json" + qs;
            var client = new HttpClient();
            var response = await client.GetAsync(url);
            response.EnsureSuccessStatusCode();

            var content = await response.Content.ReadAsAsync<T>();
            return content;
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
