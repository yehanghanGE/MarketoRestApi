using System.Net.Http;
using Newtonsoft.Json;

namespace Marketo.ApiLibrary.Mis.Request
{
    public abstract class BaseGetRequest
    {
        public string Url { get; set; }
        public virtual T Run<T>()
        {
            HttpClient client = new HttpClient();
            HttpResponseMessage response = client.GetAsync(Url).Result;
            response.EnsureSuccessStatusCode();
            string responseBody = response.Content.ReadAsStringAsync().Result;

            return JsonConvert.DeserializeObject<T>(responseBody);
        }
    }
}
