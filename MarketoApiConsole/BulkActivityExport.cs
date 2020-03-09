using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Runtime.InteropServices;
using System.Text;
using System.Threading.Tasks;
using Newtonsoft.Json;
using Newtonsoft.Json.Linq;

namespace MarketoRestApiLibrary
{
    class BulkActivityExport
    {
        private String host         = "https://529-fgg-715.mktorest.com"; //host of your marketo instance, https://AAA-BBB-CCC.mktorest.com
        private String clientId     = "1659dcfa-6624-4b17-a8a9-ccb6c5841f4e"; //clientId from admin > Launchpoint
        private String clientSecret = "cmdYVQHIVGkEwnphZISBsTtuLihMCMOz"; //clientSecret from admin > Launchpoint

        private String outputFormat = "csv";
        private String startAtTime  = "2019-8-01T23:59:59-00:00";
        private String endAt        = "2019-8-30T23:59:59-00:00";
        private readonly int[] _activityTypeIds = new int[] { 1, 2, 10, 11, 22, 46 };


        //public static void Main(string[] args)
        //{
        //    BulkActivityExport exportor = new BulkActivityExport();
        //    Console.WriteLine("============================Getting token==============================");
        //    string token = exportor.getToken();
        //    Console.WriteLine("============================Creating job==============================");
        //    string job = exportor.CreateJob(token);
        //    Console.WriteLine("============================Getting exportedId==============================");
        //    JObject jobObject = (JObject)JsonConvert.DeserializeObject(job);
        //    var result = jobObject["result"];
        //    string exportedId = result[0]["exportId"].ToString();
        //    //string exportedId = "47117888-ff7f-48e7-ba35-9e4e41d736a0";
        //    Console.WriteLine("============================Enqueuing job " + exportedId + "==============================");
        //    exportor.EnqueueJob(exportedId, token);
        //    string status = exportor.GetJobStatus(exportedId, token);
        //    while (status != "Completed")
        //    {
        //        System.Threading.Thread.Sleep(1 * 60 * 1000);
        //        status = exportor.GetJobStatus(exportedId, token);
        //        //Console.WriteLine("==============================Waiting job to be completed=====================================");
        //        Console.WriteLine("==============================" + status + "=====================================");

        //    }

        //    if (exportor.GetJobStatus(exportedId, token) == "Completed")
        //    {
        //        Console.WriteLine("==========================Job Completed, Start to retrieving===============================");
        //        string extractedData = exportor.RetrieveData(exportedId, token);
        //        System.IO.File.WriteAllText(@"D:\activitity_results001.csv", extractedData);
        //        Console.WriteLine("==========================Done!===============================");
        //        Console.ReadKey();
        //    }
        //}

        public String CreateJob(string token)
        {
            String url = host + "/bulk/v1/activities/export/create.json?access_token=" + token;
            
            var httpClient = new HttpClient();
            //var requestBody = bodyBuilder();
            //Console.WriteLine(requestBody);
            var content = new StringContent(bodyBuilder(), Encoding.UTF8, "application/json");
            var response = httpClient.PostAsync(url, content).Result;

            response.EnsureSuccessStatusCode();
            return response.Content.ReadAsStringAsync().Result;
        }
        public String EnqueueJob(string exportId, string token)
        {
            String url = host + "/bulk/v1/activities/export/"+ exportId+"/enqueue.json?access_token=" + token;
            var httpClient = new HttpClient();
            var content = new StringContent( "", Encoding.UTF8, "application/json");
            var response = httpClient.PostAsync(url, content).Result;
            response.EnsureSuccessStatusCode();
            return response.Content.ReadAsStringAsync().Result;
        }
        public String GetJobStatus(string exportId, string token)
        {
            String url = host + "/bulk/v1/activities/export/" + exportId + "/status.json?access_token=" + token;
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
        public String RetrieveData(string exportId, string token)
        {
            String url = host + "/bulk/v1/activities/export/" + exportId + "/file.json?access_token=" + token;
            HttpWebRequest request = (HttpWebRequest)WebRequest.Create(url);
            request.ContentType = "application/json";
            request.Accept = "application/json";
            HttpWebResponse response = (HttpWebResponse)request.GetResponse();
            Stream resStream = response.GetResponseStream();
            StreamReader reader = new StreamReader(resStream);
            var result = reader.ReadToEnd();
            
            return result;
        }
        private String bodyBuilder()
        {
            var requestBody = new Dictionary<string, dynamic>();
            requestBody.Add("format", outputFormat);
            var filter = new Dictionary<string, dynamic>();
            var createdAt = new Dictionary<string,string>();
            createdAt.Add("startAt", startAtTime);
            createdAt.Add("endAt", endAt);
            filter.Add("createdAt", createdAt);
            filter.Add("activityTypeIds", _activityTypeIds);
            requestBody.Add("filter", filter);
            
            return JsonConvert.SerializeObject(requestBody);
        }
        private String getToken()
        {
            String url = host + "/identity/oauth/token?grant_type=client_credentials&client_id=" + clientId + "&client_secret=" + clientSecret;
            HttpWebRequest request = (HttpWebRequest)WebRequest.Create(url);
            request.ContentType = "application/json";
            HttpWebResponse response = (HttpWebResponse)request.GetResponse();
            Stream resStream = response.GetResponseStream();
            StreamReader reader = new StreamReader(resStream);
            String json = reader.ReadToEnd();
            //Dictionary<String, Object> dict = JavaScriptSerializer.DeserializeObject(reader.ReadToEnd);
            Dictionary<String, String> dict = JsonConvert.DeserializeObject<Dictionary<String, String>>(json);
            return dict["access_token"];
        }
    }
}
