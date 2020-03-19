using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;

namespace MarketoApiLibrary.Request
{
    public abstract class BaseGetRequest
    {
        public string Url { get; set; }
        public virtual T Run<T>()
        {
            var client = new HttpClient();
            var response = client.GetAsync(Url).Result;
            response.EnsureSuccessStatusCode();
            var responseBody = response.Content.ReadAsStringAsync().Result;

            return JsonConvert.DeserializeObject<T>(responseBody);
        }
    }
}
