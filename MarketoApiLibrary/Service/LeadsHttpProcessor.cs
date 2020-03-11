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
        public static string CreateJob(LeadsExportRequest leadsExportRequest)
        {
            string url = leadsExportRequest.Host + "/bulk/v1/leads/export/create.json?access_token=" + leadsExportRequest.Token;

            var httpClient = new HttpClient();
            var content = new StringContent(Helper.BodyBuilder(leadsExportRequest.OutputFormat,
                leadsExportRequest.Fields, leadsExportRequest.Filters), Encoding.UTF8, "application/json");
            var response = httpClient.PostAsync(url, content).Result;

            response.EnsureSuccessStatusCode();
            return response.Content.ReadAsStringAsync().Result;
        }
        public static string EnqueueJob(LeadsExportRequest leadsExportRequest)
        {
            String url = leadsExportRequest.Host + "/bulk/v1/leads/export/" + leadsExportRequest.ExportId + "/enqueue.json?access_token=" + leadsExportRequest.Token;
            var httpClient = new HttpClient();
            var content = new StringContent("", Encoding.UTF8, "application/json");
            var response = httpClient.PostAsync(url, content).Result;
            response.EnsureSuccessStatusCode();
            return response.Content.ReadAsStringAsync().Result;
        }
        public static string GetJobStatus(LeadsExportRequest leadsExportRequest)
        {
            String url = leadsExportRequest.Host + "/bulk/v1/leads/export/" + leadsExportRequest.ExportId + "/status.json?access_token=" + leadsExportRequest.Token;
            HttpWebRequest request = (HttpWebRequest)WebRequest.Create(url);
            request.ContentType = "application/json";
            request.Accept = "application/json";
            HttpWebResponse response = (HttpWebResponse)request.GetResponse();
            Stream resStream = response.GetResponseStream();
            StreamReader reader = new StreamReader(resStream);
            JObject jobObject = (JObject)JsonConvert.DeserializeObject(reader.ReadToEnd());
            var result = jobObject["result"];
            string jobStatus = result[0]["status"].ToString();
            return jobStatus;
        }
        public static string RetrieveData(LeadsExportRequest leadsExportRequest)
        {
            String url = leadsExportRequest.Host + "/bulk/v1/leads/export/" + leadsExportRequest.ExportId + "/file.json?access_token=" + leadsExportRequest.Token;
            HttpWebRequest request = (HttpWebRequest)WebRequest.Create(url);
            request.ContentType = "application/json";
            request.Accept = "application/json";
            HttpWebResponse response = (HttpWebResponse)request.GetResponse();
            Stream resStream = response.GetResponseStream();
            StreamReader reader = new StreamReader(resStream);
            var result = reader.ReadToEnd();

            return result;
        }
        public static string GetLeadsByFilterType(GetLeadsByFilterTypeRequest getLeadsByFilterTypeRequest)
        {
            StringBuilder url = new StringBuilder(getLeadsByFilterTypeRequest.Host + "/rest/v1/leads.json?access_token=" + getLeadsByFilterTypeRequest.Token + "&filterType=" + getLeadsByFilterTypeRequest.FilterType + "&filterValues=" + Helper.CsvString(getLeadsByFilterTypeRequest.FilterValues));
            if (getLeadsByFilterTypeRequest.Fields != null)
            {
                url.Append("&fields=" + Helper.CsvString(getLeadsByFilterTypeRequest.Fields));
            }
            if (getLeadsByFilterTypeRequest.BatchSize > 0 && getLeadsByFilterTypeRequest.BatchSize < 300)
            {
                url.Append("&batchSize=" + getLeadsByFilterTypeRequest.BatchSize);
            }
            if (getLeadsByFilterTypeRequest.NextPageToken != null)
            {
                url.Append("&nextPageToken=" + getLeadsByFilterTypeRequest.NextPageToken);
            }
            HttpWebRequest request = (HttpWebRequest)WebRequest.Create(url.ToString());
            request.ContentType = "application/json";
            request.Accept = "application/json";
            HttpWebResponse response = (HttpWebResponse)request.GetResponse();
            Stream resStream = response.GetResponseStream();

            StreamReader reader = new StreamReader(resStream);
            return reader.ReadToEnd();
        }
    }
}
