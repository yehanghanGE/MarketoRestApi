using MarketoRestApiLibrary;
using MarketoRestApiLibrary.Request;
using Newtonsoft.Json;
using System.Collections.Generic;
using System.IO;
using System.Net;
using System.Net.Http;
using System.Text;
using System.Web;

namespace MarketoApiLibrary.Service
{
    public static class CustomObjectProcessor
    {
        public static string DescribeCustomObjects(CustomObjectsRequest request)
        {
            var qs = HttpUtility.ParseQueryString(string.Empty);
            qs.Add("access_token", request.Token);
            string url = request.Host + "/rest/v1/customobjects/" + request.Name + "/describe.json?" + qs.ToString();
            var httpClient = new HttpClient();
            var content = new StringContent("", Encoding.UTF8, "application/json");
            var response = httpClient.PostAsync(url, content).Result;
            response.EnsureSuccessStatusCode();
            return response.Content.ReadAsStringAsync().Result;
        }
        public static string ListCustomObjects(ListCustomObjectsRequest request)
        {
            var qs = HttpUtility.ParseQueryString(string.Empty);
            qs.Add("access_token", request.Token);
            if (request.Names != null)
            {
                qs.Add("names", Helper.CsvString(request.Names));
            }
            string url = request.Host + "/rest/v1/customobjects.json?" + qs.ToString();
            var httpClient = new HttpClient();
            var content = new StringContent("", Encoding.UTF8, "application/json");
            var response = httpClient.PostAsync(url, content).Result;
            response.EnsureSuccessStatusCode();
            return response.Content.ReadAsStringAsync().Result;
        }
        public static string SyncCustomObjects(CustomObjectsRequest request)
        {
            string url = request.Host + "/rest/v1/customobjects/" + request.Name + ".json?access_token=" + request.Token;
            var httpClient = new HttpClient();
            var content = new StringContent(bodyBuilder(request.Action, request.DedupeBy, request.Input), Encoding.UTF8, "application/json");
            var response = httpClient.PostAsync(url, content).Result;
            response.EnsureSuccessStatusCode();
            return response.Content.ReadAsStringAsync().Result;
        }
        private static string bodyBuilder(string action, string dedupeBy, List<Dictionary<string, dynamic>> input)
        {
            var parent = new Dictionary<string, dynamic>();
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
