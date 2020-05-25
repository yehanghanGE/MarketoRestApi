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
