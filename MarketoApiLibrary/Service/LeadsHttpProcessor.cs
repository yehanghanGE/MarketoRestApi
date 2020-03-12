using MarketoApiLibrary.Request;
using MarketoRestApiLibrary;
using MarketoRestApiLibrary.Request;
using Newtonsoft.Json;
using Newtonsoft.Json.Linq;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;

namespace MarketoApiLibrary.Service
{
    public static class LeadsHttpProcessor
    {
        public static string CreateJob(LeadsExportRequest request)
        {
            string url = request.Host + "/bulk/v1/leads/export/create.json?access_token=" + request.Token;

            var httpClient = new HttpClient();
            var content = new StringContent(Helper.BodyBuilder(request.OutputFormat,
                request.Fields, request.Filters), Encoding.UTF8, "application/json");
            var response = httpClient.PostAsync(url, content).Result;

            response.EnsureSuccessStatusCode();
            return response.Content.ReadAsStringAsync().Result;
        }
        public static string EnqueueJob(LeadsExportRequest request)
        {
            string url = request.Host + "/bulk/v1/leads/export/" + request.ExportId + "/enqueue.json?access_token=" + request.Token;
            var httpClient = new HttpClient();
            var content = new StringContent("", Encoding.UTF8, "application/json");
            var response = httpClient.PostAsync(url, content).Result;
            response.EnsureSuccessStatusCode();
            return response.Content.ReadAsStringAsync().Result;
        }
        public static string GetJobStatus(LeadsExportRequest request)
        {
            string url = request.Host + "/bulk/v1/leads/export/" + request.ExportId + "/status.json?access_token=" + request.Token;
            var httpClient = new HttpClient();
            var requestContent = new StringContent("", Encoding.UTF8, "application/json");
            var response = httpClient.PostAsync(url, requestContent).Result;
            response.EnsureSuccessStatusCode();
            var content = response.Content.ReadAsStringAsync().Result;

            JObject jobObject = (JObject)JsonConvert.DeserializeObject(content);
            var result = jobObject["result"];
            string jobStatus = result[0]["status"].ToString();
            return jobStatus;
        }
        public static string RetrieveData(LeadsExportRequest request)
        {
            string url = request.Host + "/bulk/v1/leads/export/" + request.ExportId + "/file.json?access_token=" + request.Token;
            var httpClient = new HttpClient();
            var requestContent = new StringContent("", Encoding.UTF8, "application/json");
            var response = httpClient.PostAsync(url, requestContent).Result;
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
            var httpClient = new HttpClient();
            var content = new StringContent("", Encoding.UTF8, "application/json");
            var response = httpClient.PostAsync(url.ToString(), content).Result;
            response.EnsureSuccessStatusCode();
            return response.Content.ReadAsStringAsync().Result;
        }
    }
}
