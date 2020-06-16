using System.Collections.Generic;
using System.Net.Http;
using System.Text;
using System.Web;
using Marketo.ApiLibrary.Mis.Request;
using Marketo.ApiLibrary.Mis.Utility;
using Newtonsoft.Json;

namespace Marketo.ApiLibrary.Mis.Service
{
    public static class CustomObjectProcessor
    {
        public static string DescribeCustomObjects(CustomObjectsRequest request)
        {
            System.Collections.Specialized.NameValueCollection qs = HttpUtility.ParseQueryString(string.Empty);
            qs.Add("access_token", request.Token);
            string url = request.Host + "/rest/v1/customobjects/" + request.Name + "/describe.json?" + qs.ToString();
            HttpClient httpClient = new HttpClient();
            StringContent content = new StringContent("", Encoding.UTF8, "application/json");
            HttpResponseMessage response = httpClient.PostAsync(url, content).Result;
            response.EnsureSuccessStatusCode();
            return response.Content.ReadAsStringAsync().Result;
        }
        public static string ListCustomObjects(ListCustomObjectsRequest request)
        {
            System.Collections.Specialized.NameValueCollection qs = HttpUtility.ParseQueryString(string.Empty);
            qs.Add("access_token", request.Token);
            if (request.Names != null)
            {
                qs.Add("names", Helper.CsvString(request.Names));
            }
            string url = request.Host + "/rest/v1/customobjects.json?" + qs.ToString();
            HttpClient httpClient = new HttpClient();
            StringContent content = new StringContent("", Encoding.UTF8, "application/json");
            HttpResponseMessage response = httpClient.PostAsync(url, content).Result;
            response.EnsureSuccessStatusCode();
            return response.Content.ReadAsStringAsync().Result;
        }
        public static string SyncCustomObjects(CustomObjectsRequest request)
        {
            string url = request.Host + "/rest/v1/customobjects/" + request.Name + ".json?access_token=" + request.Token;
            HttpClient httpClient = new HttpClient();
            StringContent content = new StringContent(BodyBuilder(request.Action, request.DedupeBy, request.Input), Encoding.UTF8, "application/json");
            HttpResponseMessage response = httpClient.PostAsync(url, content).Result;
            response.EnsureSuccessStatusCode();
            return response.Content.ReadAsStringAsync().Result;
        }
        private static string BodyBuilder(string action, string dedupeBy, List<Dictionary<string, dynamic>> input)
        {
            Dictionary<string, dynamic> parent = new Dictionary<string, dynamic>();
            if (action != null)
            {
                parent.Add("action", action);
            }
            if (dedupeBy != null)
            {
                parent.Add("dedupeBy", dedupeBy);
            }
            parent.Add("input", input);

            return JsonConvert.SerializeObject(parent);
        }
    }
}
