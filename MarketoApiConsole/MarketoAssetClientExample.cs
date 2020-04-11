using MarketoApiLibrary;
using MarketoApiLibrary.Asset.Folders.Response;
using MarketoApiLibrary.Provider;
using Newtonsoft.Json.Linq;
using System;
using System.Runtime.CompilerServices;

namespace MarketoApiConsole
{
    public class MarketoAssetClientExample
    {
        public static void Main(string[] args)
        {
            try
            {
                var apiConfig = ConfigurationProvider.LoadConfig();
                var host = apiConfig.Host;
                var clientId = apiConfig.ClientId;
                var clientSecret = apiConfig.ClientSecret;

                // GetFolderById example
                var client = new MarketoAssetClient(host, clientId, clientSecret);
                var result = client.GetFolderById<FoldersResponse>(83674).Result;
                //var result = client.GetFolderContents<FolderContentsResponse>(36910).Result;
                //var result = client.CreateFolder<FoldersResponse>("test_hyh", 77890,"Folder").Result;
                //var result = client.UpdateFolderMetadata<FoldersResponse>(83674, "hyh_test_updated",description:"this is a test description");
                //var result = client.DeleteFolder<FolderDeleteResponse>(83674);
                Console.WriteLine(JToken.FromObject(result).ToString());
                Console.ReadKey();
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.ToString());
            }
        }

        private static void GetFolderById(string host, string clientId, string clientSecret, int folderId)
        {
            var client = new MarketoAssetClient(host, clientId, clientSecret);
            var result = client.GetFolderById<FoldersResponse>(folderId).Result;
            Console.WriteLine(JToken.FromObject(result).ToString());
            Console.ReadKey();
        }
    }
}
