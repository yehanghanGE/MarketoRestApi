using MarketoApiLibrary.Asset.Folders.Request;
using System;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;
using System.Web;

namespace MarketoApiLibrary.Asset.Folders
{
    public static class FoldersHttpProcessor
    {

        /// <summary>
        /// POST /rest/asset/v1/folder/{id}.json
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <param name="request"></param>
        /// <returns></returns>
        public static async Task<T> UpdateFolderMetadata<T>(UpdateFolderMetadataRequest request)
        {
            var qs = HttpUtility.ParseQueryString(string.Empty);
            qs.Add("access_token", request.Token);
            qs.Add("isArchive", request.IsArchive.ToString());
            if (!string.IsNullOrEmpty(request.FolderName))
            {
                qs.Add("name", request.FolderName);
            }

            if (!string.IsNullOrEmpty(request.Description))
            {
                qs.Add("description", request.Description);
            }

            var url = request.Host + $"/rest/asset/v1/folder/{request.FolderId}.json?" + qs;
            var client = new HttpClient();
            var content = new StringContent("", Encoding.UTF8, "application/json");
            var response = await client.PostAsync(url, content);
            response.EnsureSuccessStatusCode();
            T result;
            try
            {
                result = await response.Content.ReadAsAsync<T>();
            }
            catch (Exception e)
            {
                Console.WriteLine(e);
                throw;
            }

            return result;
        }

    }
}
