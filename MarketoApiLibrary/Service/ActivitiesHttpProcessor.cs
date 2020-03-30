using MarketoApiLibrary.Request;
using Newtonsoft.Json;
using Newtonsoft.Json.Linq;
using System.Collections.Generic;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;

namespace MarketoApiLibrary.Service
{
    public static class ActivitiesHttpProcessor
    {
        public static string CreateJob(ActivitiesExportRequest request)
        {
            string url = request.Host + "/bulk/v1/activities/export/create.json?access_token=" + request.Token;

            HttpClient httpClient = new HttpClient();
            StringContent content = new StringContent(BodyBuilder(request.OutputFormat, request.Filters), Encoding.UTF8, "application/json");
            HttpResponseMessage response = httpClient.PostAsync(url, content).Result;
            response.EnsureSuccessStatusCode();
            return response.Content.ReadAsStringAsync().Result;
        }
        public static string EnqueueJob(ActivitiesExportRequest request)
        {
            string url = request.Host + "/bulk/v1/activities/export/" + request.ExportId + "/enqueue.json?access_token=" + request.Token;
            HttpClient httpClient = new HttpClient();
            StringContent content = new StringContent("", Encoding.UTF8, "application/json");
            HttpResponseMessage response = httpClient.PostAsync(url, content).Result;
            response.EnsureSuccessStatusCode();
            return response.Content.ReadAsStringAsync().Result;
        }
        public static string GetJobStatus(ActivitiesExportRequest request)
        {
            string url = request.Host + "/bulk/v1/activities/export/" + request.ExportId + "/status.json?access_token=" + request.Token;
            HttpClient client = new HttpClient();
            HttpResponseMessage response = client.GetAsync(url).Result;
            response.EnsureSuccessStatusCode();
            string content = response.Content.ReadAsStringAsync().Result;

            JObject jobObject = (JObject)JsonConvert.DeserializeObject(content);
            JToken result = jobObject["result"];
            string jobStatus = result[0]["status"].ToString();
            return jobStatus;
        }
        public static async Task<string> Export(ActivitiesExportRequest request)
        {
            string url = request.Host + "/bulk/v1/activities/export/" + request.ExportId + "/file.json?access_token=" + request.Token;
            HttpClient client = new HttpClient();
            HttpResponseMessage response = await client.GetAsync(url);
            response.EnsureSuccessStatusCode();

            string content = await response.Content.ReadAsStringAsync();
            return content;
        }

        //TODO extract to different file
        private static string BodyBuilder(string outputFormat, Dictionary<string, dynamic> filter)
        {
            Dictionary<string, dynamic> requestBody = new Dictionary<string, dynamic>();
            requestBody.Add("format", outputFormat);

            requestBody.Add("filter", filter);

            return JsonConvert.SerializeObject(requestBody);
        }

    }
}
