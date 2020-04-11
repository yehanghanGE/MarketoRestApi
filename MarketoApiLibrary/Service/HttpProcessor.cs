using MarketoApiLibrary.Request;
using System.Net.Http;
using System.Threading.Tasks;

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

       
    }
}
