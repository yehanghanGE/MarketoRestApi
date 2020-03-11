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
        public static string DescribeCustomObjects(CustomObjectsRequest customObjectsRequest)
        {
            var qs = HttpUtility.ParseQueryString(string.Empty);
            qs.Add("access_token", customObjectsRequest.Token);
            string url = customObjectsRequest.Host + "/rest/v1/customobjects/" + customObjectsRequest.Name + "/describe.json?" + qs.ToString();
            HttpWebRequest request = (HttpWebRequest)WebRequest.Create(url);
            request.ContentType = "application/json";
            request.Accept = "application/json";
            HttpWebResponse response = (HttpWebResponse)request.GetResponse();
            Stream resStream = response.GetResponseStream();
            StreamReader reader = new StreamReader(resStream);
            return reader.ReadToEnd();
        }

        public static string ListCustomObjects(ListCustomObjectsRequest listCustomObjectsRequest)
        {
            var qs = HttpUtility.ParseQueryString(string.Empty);
            qs.Add("access_token", listCustomObjectsRequest.Token);
            if (listCustomObjectsRequest.Names != null)
            {
                qs.Add("names", Helper.CsvString(listCustomObjectsRequest.Names));
            }
            string url = listCustomObjectsRequest.Host + "/rest/v1/customobjects.json?" + qs.ToString();
            HttpWebRequest request = (HttpWebRequest)WebRequest.Create(url);
            request.ContentType = "application/json";
            request.Accept = "application/json";
            HttpWebResponse response = (HttpWebResponse)request.GetResponse();
            Stream resStream = response.GetResponseStream();
            StreamReader reader = new StreamReader(resStream);
            return reader.ReadToEnd();
        }
        public static string SyncCustomObjects(CustomObjectsRequest customObjectsRequest)
        {
            string url = customObjectsRequest.Host + "/rest/v1/customobjects/" + customObjectsRequest.Name + ".json?access_token=" + customObjectsRequest.Token;
            var httpClient = new HttpClient();
            var content = new StringContent(bodyBuilder(customObjectsRequest.Action, customObjectsRequest.DedupeBy, customObjectsRequest.Input), Encoding.UTF8, "application/json");
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
