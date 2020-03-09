using MarketoRestApiLibrary;
using MarketoRestApiLibrary.Model;
using System;
using Newtonsoft.Json;
using MarketoRestApiLibrary.Provider;
using MarketoRestApiLibrary.Service;

namespace MarketoApiConsole
{
    class Program
    {
        public static void Main(string[] args)
        {
            var apiConfig = ConfigurationProvider.LoadConfig();
            var host = apiConfig.Host;
            var clientId = apiConfig.ClientId;
            var clientSecret = apiConfig.ClientSecret;
            var token = TokenProvider.GetToken(host, clientId, clientSecret);
            // getfoldersByName
            //var getFolderByNameRequest = RequestFactory.CreateGetFolderByNameRequest(host, token);

            //var getFolderByNameResult = HttpProcessor.GetFolderByName(getFolderByNameRequest);
            //var jsonFormatted = JToken.Parse(getFolderByNameResult).ToString(Formatting.Indented);
            //Console.WriteLine(jsonFormatted);
            // getFolders
            //var getFoldersRequest = RequestFactory.CreateGetFoldersRequest(host, token);
            //var foldersResult = HttpProcessor.GetFolders(getFoldersRequest);
            //var jsonFormatted = JToken.Parse(foldersResult).ToString(Formatting.Indented);
            //Console.WriteLine(jsonFormatted);

            // getfiles
            var getFilesRequest = RequestFactory.CreateGetFilesRequest(host, token);

            var filesResult = HttpProcessor.GetFiles(getFilesRequest);

            GetFilesResponse obj = JsonConvert.DeserializeObject<GetFilesResponse>(filesResult);
            string savePath = @"D:\DownloadedImageFromMarketo";

            foreach (MarketoFile file in obj.Result)
            {
                System.Drawing.Image image = ImageDownloader.DownloadImageFromUrl(file.Url.Trim());
                string fileName = System.IO.Path.Combine(savePath, file?.Name);
                Console.WriteLine(fileName);
                image.Save(fileName);
            }
            Console.WriteLine("Done!");

            //var filesjsonFormatted = JToken.Parse(filesResult).ToString(Formatting.Indented);

            //Console.WriteLine(filesjsonFormatted);
            // getActivityTypes
            //var request = RequestFactory.CreategetActivityTypesResult(host, token);
            //var getActivityTypesResult = HttpProcessor.GetActivityTypes(request);
            //var jsonFormatted = JToken.Parse(getActivityTypesResult).ToString(Formatting.Indented);
            //Console.WriteLine(jsonFormatted);
            Console.ReadKey();
        }
    }
}
