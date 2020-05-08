﻿using MarketoApiLibrary.Model;
using MarketoApiLibrary.Provider;
using MarketoApiLibrary.Request;
using MarketoApiLibrary.Service;
using Newtonsoft.Json;
using Newtonsoft.Json.Linq;
using System;
using System.Threading.Tasks;
using MarketoApiLibrary.Asset.Files;
using MarketoApiLibrary.Asset.Files.Request;
using MarketoApiLibrary.Asset.Files.Response;
using MarketoApiLibrary.Asset.Folders;
using MarketoApiLibrary.Asset.Folders.Request;
using MarketoApiLibrary.Asset.Folders.Response;
using MarketoApiLibrary.Asset.SmartLists;
using MarketoApiLibrary.Response;

namespace MarketoApiLibrary
{
    public class MarketoClient : IMarketoClient
    {
        private readonly string _host;
        private readonly string _clientId;
        private readonly string _clientSecret;
        private readonly string _token;
        private readonly IRequestFactory _requestFactorty;
        private readonly ITokenProvider _tokenProvider;
        public MarketoClient(string host, string clientId, string clientSecret)
        {
            _host = host;
            _clientId = clientId;
            _clientSecret = clientSecret;
            _tokenProvider = new TokenProvider();
            _token = _tokenProvider.GetTokenAsync(host, clientId, clientSecret).Result;
            _requestFactorty = new RequestFactory();
        }
      

        public Task<FoldersResponse> GetFolders(string rootFolderId)
        {
            GetFoldersRequest request = _requestFactorty.CreateGetFoldersRequest(_host, _token, rootFolderId);
            var folders = FoldersHttpProcessor.GetFolders<FoldersResponse>(request);
            return folders;
        }

        public void BulkExportLeads()
        {
            Console.WriteLine("============================Getting token==============================");
            Console.WriteLine("============================Creating job==============================");

            LeadsExportRequest leadsExportRequest = _requestFactorty.CreateGetLeadsExportRequest(_host, _token);

            string job = LeadsHttpProcessor.CreateJob(leadsExportRequest);
            Console.WriteLine("============================Getting exportedId==============================");
            JObject jobObject = (JObject)JsonConvert.DeserializeObject(job);
            JToken result = jobObject["result"];
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

        public async Task<FilesResponse> GetFiles(string folderId, int offSet)
        {
            GetFilesRequest request = _requestFactorty.CreateGetFilesRequest(_host, _token, folderId, offSet);
            FilesResponse result = await FilesHttpProcessor.GetFiles<FilesResponse>(request);
            return result;

        }
        public void BulkExportActivities()
        {
            Console.WriteLine("============================Getting token==============================");
            Console.WriteLine("============================Creating job==============================");

            ActivitiesExportRequest request = _requestFactorty.CreateActivitiesExportRequest(_host, _token);
            string job = ActivitiesHttpProcessor.CreateJob(request);
            Console.WriteLine("============================Getting exportedId==============================");
            JObject jobObject = (JObject)JsonConvert.DeserializeObject(job);
            JToken result = jobObject["result"];
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
            CustomObjectsRequest request = _requestFactorty.CreateCustomObjectsRequest(_host, _token);
            string result = CustomObjectProcessor.DescribeCustomObjects(request);
            return result;
        }
        public string SyncCustomObjects()
        {
            CustomObjectsRequest request = _requestFactorty.CreateCustomObjectsRequest(_host, _token);
            string result = CustomObjectProcessor.SyncCustomObjects(request);
            return result;
        }
    }
}

