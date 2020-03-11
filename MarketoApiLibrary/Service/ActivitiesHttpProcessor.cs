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
    public static class ActivitiesHttpProcessor
    {
        public static string CreateJob(ActivitiesExportRequest activitiesExportRequest)
        {
            String url = activitiesExportRequest.Host + "/bulk/v1/activities/export/create.json?access_token=" + activitiesExportRequest.Token;

            var httpClient = new HttpClient();
            var content = new StringContent(bodyBuilder(activitiesExportRequest.OutputFormat, activitiesExportRequest.Filters), Encoding.UTF8, "application/json");
            var response = httpClient.PostAsync(url, content).Result;
            response.EnsureSuccessStatusCode();
            return response.Content.ReadAsStringAsync().Result;
        }
        public static string EnqueueJob(ActivitiesExportRequest activitiesExportRequest)
        {
            String url = activitiesExportRequest.Host + "/bulk/v1/activities/export/" + activitiesExportRequest.ExportId + "/enqueue.json?access_token=" + activitiesExportRequest.Token;
            var httpClient = new HttpClient();
            var content = new StringContent("", Encoding.UTF8, "application/json");
            var response = httpClient.PostAsync(url, content).Result;
            response.EnsureSuccessStatusCode();
            return response.Content.ReadAsStringAsync().Result;
        }
        public static string GetJobStatus(ActivitiesExportRequest activitiesExportRequest)
        {
            String url = activitiesExportRequest.Host + "/bulk/v1/activities/export/" + activitiesExportRequest.ExportId + "/status.json?access_token=" + activitiesExportRequest.Token;
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
        public static string RetrieveData(ActivitiesExportRequest activitiesExportRequest)
        {
            String url = activitiesExportRequest.Host + "/bulk/v1/activities/export/" + activitiesExportRequest.ExportId + "/file.json?access_token=" + activitiesExportRequest.Token;
            HttpWebRequest request = (HttpWebRequest)WebRequest.Create(url);
            request.ContentType = "application/json";
            request.Accept = "application/json";
            HttpWebResponse response = (HttpWebResponse)request.GetResponse();
            Stream resStream = response.GetResponseStream();
            StreamReader reader = new StreamReader(resStream);
            var result = reader.ReadToEnd();

            return result;
        }

        //TODO extract to different file
        private static string bodyBuilder(string outputFormat, Dictionary<string, dynamic> filter)
        {
            var requestBody = new Dictionary<string, dynamic>();
            requestBody.Add("format", outputFormat);

            requestBody.Add("filter", filter);

            return JsonConvert.SerializeObject(requestBody);
        }

        public static string AddCustomActivities()
        {
            return "";
        }

    }
}
