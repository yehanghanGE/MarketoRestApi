using MarketoApiLibrary.Request;
using MarketoApiLibrary.Utility;
using Newtonsoft.Json;
using Newtonsoft.Json.Linq;
using System.Net.Http;
using System.Text;

namespace MarketoApiLibrary.Service
{
    public static class LeadsHttpProcessor
    {
        public static string CreateJob(LeadsExportRequest request)
        {
            string url = request.Host + "/bulk/v1/leads/export/create.json?access_token=" + request.Token;

            HttpClient httpClient = new HttpClient();
            StringContent content = new StringContent(Helper.BodyBuilder(request.OutputFormat,
                request.Fields, request.Filters), Encoding.UTF8, "application/json");
            HttpResponseMessage response = httpClient.PostAsync(url, content).Result;

            response.EnsureSuccessStatusCode();
            return response.Content.ReadAsStringAsync().Result;
        }
        public static string EnqueueJob(LeadsExportRequest request)
        {
            string url = request.Host + "/bulk/v1/leads/export/" + request.ExportId + "/enqueue.json?access_token=" + request.Token;
            HttpClient httpClient = new HttpClient();
            StringContent content = new StringContent("", Encoding.UTF8, "application/json");
            HttpResponseMessage response = httpClient.PostAsync(url, content).Result;
            response.EnsureSuccessStatusCode();
            return response.Content.ReadAsStringAsync().Result;
        }
        public static string GetJobStatus(LeadsExportRequest request)
        {
            string url = request.Host + "/bulk/v1/leads/export/" + request.ExportId + "/status.json?access_token=" + request.Token;
            HttpClient httpClient = new HttpClient();
            StringContent requestContent = new StringContent("", Encoding.UTF8, "application/json");
            HttpResponseMessage response = httpClient.PostAsync(url, requestContent).Result;
            response.EnsureSuccessStatusCode();
            string content = response.Content.ReadAsStringAsync().Result;

            JObject jobObject = (JObject)JsonConvert.DeserializeObject(content);
            JToken result = jobObject["result"];
            string jobStatus = result[0]["status"].ToString();
            return jobStatus;
        }
        public static string RetrieveData(LeadsExportRequest request)
        {
            string url = request.Host + "/bulk/v1/leads/export/" + request.ExportId + "/file.json?access_token=" + request.Token;
            HttpClient httpClient = new HttpClient();
            StringContent requestContent = new StringContent("", Encoding.UTF8, "application/json");
            HttpResponseMessage response = httpClient.PostAsync(url, requestContent).Result;
            response.EnsureSuccessStatusCode();
            return response.Content.ReadAsStringAsync().Result; ;
        }
        public static string GetLeadsByFilterType(GetLeadsByFilterTypeRequest request)
        {
            StringBuilder url = new StringBuilder(request.Host + "/rest/v1/leads.json?access_token=" + request.Token
                + "&filterType=" + request.FilterType + "&filterValues=" + Helper.CsvString(request.FilterValues));
            if (request.Fields != null)
            {
                url.Append("&fields=" + Helper.CsvString(request.Fields));
            }
            if (request.BatchSize > 0 && request.BatchSize < 300)
            {
                url.Append("&batchSize=" + request.BatchSize);
            }
            if (request.NextPageToken != null)
            {
                url.Append("&nextPageToken=" + request.NextPageToken);
            }
            HttpClient httpClient = new HttpClient();
            StringContent content = new StringContent("", Encoding.UTF8, "application/json");
            HttpResponseMessage response = httpClient.PostAsync(url.ToString(), content).Result;
            response.EnsureSuccessStatusCode();
            return response.Content.ReadAsStringAsync().Result;
        }
    }
}
