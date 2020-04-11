using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;
using MarketoApiLibrary.Request;

namespace MarketoApiLibrary.Asset.SmartLists
{
    public static class SmartListsHttpProcessor
    {
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
