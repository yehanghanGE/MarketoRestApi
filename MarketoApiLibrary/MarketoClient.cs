using MarketoApiLibrary.Service;
using MarketoRestApiLibrary.Provider;
using MarketoRestApiLibrary.Request;
using MarketoRestApiLibrary.Service;
using Newtonsoft.Json;
using Newtonsoft.Json.Linq;
using System;
using System.Threading.Tasks;

namespace MarketoApiLibrary
{
    public class MarketoClient : IMarketoClient
    {
        private readonly string Host;
        private readonly string ClientId;
        private readonly string ClientSecret;
        private readonly string Token;
        public MarketoClient(string host, string clientId, string clientSecret)
        {
            Host = host;
            ClientId = clientId;
            ClientSecret = clientSecret;
            Token = TokenProvider.GetTokenAsync(host, clientId, clientSecret).Result;
        }
        public async Task<string> GetSmartList()
        {
            var getSmartListRequest = RequestFactory.CreateGetSmartListRequest(Host, Token);
            var smartListResult = await HttpProcessor.GetSmartList(getSmartListRequest);
            return smartListResult;
        }
        public void BulkExportLeads()
        {
            Console.WriteLine("============================Getting token==============================");
            Console.WriteLine("============================Creating job==============================");

            LeadsExportRequest leadsExportRequest = RequestFactory.CreateGetLeadsExportRequest(Host, Token);

            string job = LeadsHttpProcessor.CreateJob(leadsExportRequest);
            Console.WriteLine("============================Getting exportedId==============================");
            JObject jobObject = (JObject)JsonConvert.DeserializeObject(job);
            var result = jobObject["result"];
            string exportedId = result[0]["exportId"].ToString();
            leadsExportRequest.ExportId = exportedId;

            Console.WriteLine("============================Enqueuing job " + exportedId + "==============================");
            LeadsHttpProcessor.EnqueueJob(leadsExportRequest);
            string status = LeadsHttpProcessor.GetJobStatus(leadsExportRequest);
            while (status != "Completed")
            {
                System.Threading.Thread.Sleep(1 * 60 * 1000);
                status = status = LeadsHttpProcessor.GetJobStatus(leadsExportRequest);
                //Console.WriteLine("==============================Waiting job to be completed=====================================");
                Console.WriteLine("==============================" + status + "=====================================");

            }

            if (LeadsHttpProcessor.GetJobStatus(leadsExportRequest) == "Completed")
            {
                Console.WriteLine("==========================Job Completed, Start to retrieving===============================");
                string extractedData = LeadsHttpProcessor.RetrieveData(leadsExportRequest);
                System.IO.File.WriteAllText(@"D:\List_Import_Leads.csv", extractedData);
                Console.WriteLine("==========================Done!===============================");
                Console.ReadKey();
            }
        }

        public void BulkExportActivities()
        {
            Console.WriteLine("============================Getting token==============================");
            Console.WriteLine("============================Creating job==============================");

            var request = RequestFactory.CreateActivitiesExportRequest(Host, Token);
            string job = ActivitiesHttpProcessor.CreateJob(request);
            Console.WriteLine("============================Getting exportedId==============================");
            JObject jobObject = (JObject)JsonConvert.DeserializeObject(job);
            var result = jobObject["result"];
            string exportedId = result[0]["exportId"].ToString();
            request.ExportId = exportedId;
            Console.WriteLine("============================Enqueuing job " + exportedId + "==============================");
            ActivitiesHttpProcessor.EnqueueJob(request);
            string status = ActivitiesHttpProcessor.GetJobStatus(request);
            while (status != "Completed")
            {
                System.Threading.Thread.Sleep(1 * 60 * 1000);
                status = ActivitiesHttpProcessor.GetJobStatus(request);
                //Console.WriteLine("==============================Waiting job to be completed=====================================");
                Console.WriteLine("==============================" + status + "=====================================");

            }

            if (ActivitiesHttpProcessor.GetJobStatus(request) == "Completed")
            {
                Console.WriteLine("==========================Job Completed, Start to retrieving===============================");
                string extractedData = ActivitiesHttpProcessor.Export(request).Result;
                System.IO.File.WriteAllText(@"D:\activitity_results001.csv", extractedData);
                Console.WriteLine("==========================Done!===============================");
                Console.ReadKey();
            }
        }

        public string DescribeCustomObjects()
        {
            var request = RequestFactory.CreateCustomObjectsRequest(Host, Token);
            var result = CustomObjectProcessor.DescribeCustomObjects(request);
            return result;
        }

        public string SyncCustomObjects()
        {
            var request = RequestFactory.CreateCustomObjectsRequest(Host, Token);
            var result = CustomObjectProcessor.SyncCustomObjects(request);
            return result;
        }
    }
}
