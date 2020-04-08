
using System.Collections.Specialized;
using System.Net.Http;
using System.Threading.Tasks;
using System.Web;
using MarketoApiLibrary.Model;
using MarketoApiLibrary.Request;
using MarketoApiLibrary.Response;
using Newtonsoft.Json;

namespace MarketoApiLibrary.Service
{
    public static class HttpProcessor
    {
        public static async Task<string> GetActivityTypes(BaseRequest request)
        {
            string url = request.Host + "/rest/v1/activities/types.json?access_token=" + request.Token;
            HttpClient client = new HttpClient();
            HttpResponseMessage response = await client.GetAsync(url);
            response.EnsureSuccessStatusCode();

            string content = await response.Content.ReadAsStringAsync();
            return content;
        }

        public static async Task<string> GetSmartList(BaseRequest request)
        {
            string url = request.Host + "/rest/asset/v1/staticLists.json?access_token=" + request.Token;

            HttpClient client = new HttpClient();
            HttpResponseMessage response = await client.GetAsync(url);
            response.EnsureSuccessStatusCode();

            string content = await response.Content.ReadAsStringAsync();
            return content;
        }
    }
}
