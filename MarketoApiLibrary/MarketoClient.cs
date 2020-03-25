using MarketoApiLibrary.Request;
using MarketoApiLibrary.Service;
using MarketoRestApiLibrary.Model;
using MarketoRestApiLibrary.Provider;
using MarketoRestApiLibrary.Request;
using MarketoRestApiLibrary.Service;
using Newtonsoft.Json;
using Newtonsoft.Json.Linq;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using System.Web;

namespace MarketoApiLibrary
{
    public class MarketoClient : IMarketoClient
    {
        private readonly string Host;
        private readonly string ClientId;
        private readonly string ClientSecret;
        private readonly string Token;
        private readonly IRequestFactory requestFactorty;
        private readonly ITokenProvider tokenProvider;
        public MarketoClient(string host, string clientId, string clientSecret)
        {
            Host = host;
            ClientId = clientId;
            ClientSecret = clientSecret;
            tokenProvider = new TokenProvider();
            Token = tokenProvider.GetTokenAsync(host, clientId, clientSecret).Result;
            requestFactorty = new RequestFactory();
        }
        public async Task<string> GetSmartList()
        {
            var getSmartListRequest = requestFactorty.CreateGetSmartListRequest(Host, Token);
            var smartListResult = await HttpProcessor.GetSmartList(getSmartListRequest);
            return smartListResult;
        }
        public T GetSmartList<T>(bool isJson)
        {
            var getSmartListRequest = new GetSmartListRequest()
            {
                Url = Host + "/rest/asset/v1/staticLists.json?access_token=" + Token
            };
            var result = getSmartListRequest.Run<T>();
            return result;
        }

        public Task<GetFoldersResponse> GetFolders(bool isJson)
        {
            var request = requestFactorty.CreateGetFoldersRequest(Host, Token);
            var folders = HttpProcessor.GetFolders(request);
            return folders;
        }

        public void BulkExportLeads()
        {
            Console.WriteLine("============================Getting token==============================");
            Console.WriteLine("============================Creating job==============================");

            LeadsExportRequest leadsExportRequest = requestFactorty.CreateGetLeadsExportRequest(Host, Token);

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
        public T GetFiles<T>(string folderId, string offSet)
        {
            Dictionary<string, dynamic> folder = new Dictionary<string, dynamic>();
            folder.Add("id", folderId);
            folder.Add("type", "Folder");
            var qs = HttpUtility.ParseQueryString(string.Empty);
            qs.Add("access_token", Token);
            if (folder != null)
            {
                qs.Add("folder", JsonConvert.SerializeObject(folder));
            }
            //if (request.Offset > 0)
            //{
            qs.Add("offset", offSet);
            //}
            //if (request.MaxReturn > 0)
            //{
            qs.Add("maxReturn", "200");
            //}
            string url = Host + "/rest/asset/v1/files.json?" + qs.ToString();
            var getFilesRequest = new GetFilesRequest()
            {
                Url = url
            };
            var result = getFilesRequest.Run<T>();
            return result;
        }
        public void BulkExportActivities()
        {
            Console.WriteLine("============================Getting token==============================");
            Console.WriteLine("============================Creating job==============================");

            var request = requestFactorty.CreateActivitiesExportRequest(Host, Token);
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
            var request = requestFactorty.CreateCustomObjectsRequest(Host, Token);
            var result = CustomObjectProcessor.DescribeCustomObjects(request);
            return result;
        }
        public string SyncCustomObjects()
        {
            var request = requestFactorty.CreateCustomObjectsRequest(Host, Token);
            var result = CustomObjectProcessor.SyncCustomObjects(request);
            return result;
        }
    }
}

