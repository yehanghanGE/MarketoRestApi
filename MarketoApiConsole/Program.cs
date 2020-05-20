using MarketoApiLibrary;
using System;
using System.Collections.Generic;
using System.IO;
using MarketoApiLibrary.Asset.Files.Response;
using MarketoApiLibrary.Asset.Folders.Response;
using MarketoApiLibrary.Mis.Utility;
using Newtonsoft.Json.Linq;

namespace MarketoApiConsole
{
    public class Program
    {
        //public static void Main(string[] args)
        //{
        //    try
        //    {
        //        ApiConfig apiConfig = ConfigurationProvider.LoadConfig();
        //        string host = apiConfig.Host;
        //        string clientId = apiConfig.ClientId;
        //        string clientSecret = apiConfig.ClientSecret;

        //        //GetSmartList(host, clientId, clientSecret);
        //        // The destination folder URLs are: "30844"
        //        //https://app-sj02.marketo.com/#FI0A1ZN76278
        //        //https://app-sj02.marketo.com/#FI0A1ZN76359
        //        //var folderIds = new List<string> { "76278", "49092", "36910", "49184", "64594", "64595", "64596",
        //        //                                   "43942", "51205", "51206", "51207", "51208", "53876", "55694",
        //        //                                   "59285", "61840", "34211", "69746","30838", "51251", "51250",
        //        //                                   "51249", "55029", "61035", "65917", "69019", "74231", "42278" };
        //        //var folderIds = new List<string>{ "76359","35467","40733","54025","51259","52904",
        //        //                                  "47865","46098","52951","43462","52357","49792","48470",
        //        //                                  "47202","54034","59952","65937","62541","59951","63661","66800"};
        //        //var folderIds = new List<string> { "30844" };
        //        //var folderIds = new List<string> { "79047", "45169","48095","47968","54651","55105","54964",
        //        //                                    "55162","55158","55067","55072","50671","46406","49445",
        //        //                                    "62842","65113","49005","47462","52936","45603",
        //        //                                    "51337","44073"};
        //        // var folderIds = new List<string> { "77128", "76383" };
        //        //var folderIds = new List<string> { "76383", "30846", "56935", "75680", "67334", "69523", "39438",
        //        //                                    "35469", "47159","54738", "45192", "49518", "51397", "40497",
        //        //                                    "36037","49582","54150","37783","41502","44521","50537"};

        //        //DownFile(host, clientId, clientSecret, folderIds, @"D:\DownloadedImageFromMarketo");
        //        //List<string> folderIds = GetSubFolderIDs(host, clientId, clientSecret, "76383");
        //        //DownFile(host, clientId, clientSecret, folderIds, @"D:\DownloadedImageFromMarketo");
        //        //GetFileByName(host, clientId, clientSecret, "bg-blue.png");
        //        //GetFileById(host, clientId, clientSecret, 1004103);2452142
        //        //CreateFile(host, clientId, clientSecret, @"C:\\Users\\212616592\\Pictures\\Robot.jpg");
        //        //UpdateFile(host, clientId, clientSecret, @"C:\\Projects\\MarketoRestApi\\MarketoApiLibrary\\Constants.cs", "2452142");
        //        //GetFolderByName(host, clientId, clientSecret, "Template images", 34407);
        //        var apiHelper = new ApiHelper();
        //        var result  = apiHelper.Authenticate().Result;

        //    }
        //    catch (Exception ex)
        //    {
        //        Console.WriteLine(ex.ToString());
        //    }
        //}

        //private static void GetFolderByName(string host, string clientId, string clientSecret, string folderName, int parentFolderId)
        //{
        //    var client = new MarketoAssetClient(host);
        //    var result = client.GetFolderByName<FoldersResponse>(folderName, parentFolderId).Result;
        //    Console.WriteLine(JToken.FromObject(result).ToString());
        //    Console.ReadKey();
        //}

        //private static void UpdateFile(string host, string clientId, string clientSecret, string filePath, string fileId)
        //{
        //    var client = new MarketoAssetClient(host);
        //    var result = client.UpdateFile<FilesResponse>(filePath,fileId).Result;
        //    Console.WriteLine(JToken.FromObject(result).ToString());
        //    Console.ReadKey();
        //}
        //private static void CreateFile(string host, string clientId, string clientSecret, string filePath)
        //{
        //    var client = new MarketoAssetClient(host);
        //    var result = client.CreateFile<FilesResponse>(filePath).Result;
        //    Console.WriteLine(JToken.FromObject(result).ToString());
        //    Console.ReadKey();
        //}

        //private static void GetFileById(string host, string clientId, string clientSecret, int fileId)
        //{
        //    var client = new MarketoAssetClient(host);
        //    var result = client.GetFileById<FilesResponse>(fileId).Result;
        //    Console.WriteLine(JToken.FromObject(result).ToString());
        //    Console.ReadKey();
        //}

        //private static void GetFileByName(string host, string clientId, string clientSecret, string fileName)
        //{
        //    var client = new MarketoAssetClient(host);
        //    var result = client.GetFileByName<FilesResponse>(fileName).Result;
        //    Console.WriteLine(JToken.FromObject(result).ToString());
        //    Console.ReadKey();
        //}
        //private static void GetSmartList(string host, string clientId, string clientSecret)
        //{
           
        //}

        //private static List<string> GetSubFolderIDs(string host, string clientId, string clientSecret, string rootFolderId)
        //{
        //    MarketoClient client = new MarketoClient(host, clientId, clientSecret);
        //    var result = client.GetFolders(rootFolderId).Result;
        //    List<string> folderIDs = new List<string>();
        //    if (result.Result != null)
        //    {
        //        foreach (FolderResponse folder in result.Result)
        //        {
        //            folderIDs.Add(folder.Id.ToString());
        //        }
        //    }
        //    return folderIDs;
        //    //string prettyJson = JToken.Parse(result).ToString(Formatting.Indented);
        //}
        //private static void DownFile(string host, string clientId, string clientSecret, List<string> folderIds, string savePath)
        //{
        //    MarketoClient client = new MarketoClient(host, clientId, clientSecret);
        //    foreach (string folderId in folderIds)
        //    {
        //        Console.WriteLine(folderId);
        //        FilesResponse fileResult = client.GetFiles(folderId, 0).Result;
        //        string saveRootPath = Path.Combine(savePath, folderId);

        //        if (fileResult?.Result != null)
        //        {
        //            if (!Directory.Exists(saveRootPath))
        //            {
        //                Directory.CreateDirectory(saveRootPath);
        //            }
        //            WriteFileToDisk(fileResult, saveRootPath);
        //            if (fileResult.Result.Count >= 200)
        //            {
        //                MarketoClient client200 = new MarketoClient(host, clientId, clientSecret);
        //                FilesResponse fileResult200 = client200.GetFiles(folderId, 200).Result;
        //                if (fileResult200?.Result != null)
        //                {
        //                    WriteFileToDisk(fileResult200, saveRootPath);
        //                }
        //            }
        //        }
        //        Console.WriteLine("Done!");
        //    }
        //    Console.ReadKey();
        //}
        //private static void WriteFileToDisk(FilesResponse fileResult, string saveRootPath)
        //{
        //    if (fileResult?.Result == null) return;
        //    foreach (FileResponse file in fileResult?.Result)
        //    {
        //        string fileName = Path.Combine(saveRootPath, file.Name);
        //        FileDownloader.DownFile(file.Url, fileName);
        //        Console.WriteLine(file?.Url);
        //    }
        //}
    }
}
