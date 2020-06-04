using MarketoApiLibrary.Asset.Folders.Request;
using Newtonsoft.Json;
using System;
using System.Collections.Specialized;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;
using System.Web;

namespace MarketoApiLibrary.Asset.Folders
{
    public static class FoldersHttpProcessor
    {


        /// <summary>
        /// GET /rest/asset/v1/folder/{id}.json
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <param name="request"></param>
        /// <returns></returns>
        public static async Task<T> GetFolderById<T>(GetFolderByIdRequest request)
        {
            NameValueCollection qs = HttpUtility.ParseQueryString(string.Empty);
            qs.Add("access_token", request.Token);
            qs.Add("type", request.FolderType);
            var url = request.Host + $"/rest/asset/v1/folder/{request.FolderId}.json?" + qs;
            HttpClient client = new HttpClient();
            HttpResponseMessage response = await client.GetAsync(url);
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
        /// <summary>
        /// GET /rest/asset/v1/folder/{id}/content.json
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <param name="request"></param>
        /// <returns></returns>
        public static async Task<T> GetFolderContents<T>(GetFolderContentsRequest request)
        {
            var qs = HttpUtility.ParseQueryString(string.Empty);
            qs.Add("access_token", request.Token);
            qs.Add("type", request.FolderType);
            if (request.Offset > 0)
            {
                qs.Add("offset", request.Offset.ToString());
            }
            if (request.MaxReturn > 0)
            {
                qs.Add("maxReturn", request.MaxReturn.ToString());
            }

            var url = request.Host + $"/rest/asset/v1/folder/{request.FolderId}/content.json?" + qs;
            var client = new HttpClient();
            var response = await client.GetAsync(url);
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
        /// <summary>
        /// POST /rest/asset/v1/folders.json
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <param name="request"></param>
        /// <returns></returns>
        public static async Task<T> CreateFolder<T>(CreateFolderRequest request)
        {
            var qs = HttpUtility.ParseQueryString(string.Empty);
            qs.Add("access_token", request.Token);
            qs.Add("parent", JsonConvert.SerializeObject(request.Parent));
            qs.Add("name", request.FolderName);
            qs.Add("description", request.Description);

            var url = request.Host + $"/rest/asset/v1/folders.json?" + qs;
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
        /// <summary>
        /// POST /rest/asset/v1/folder/{id}/delete.json
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <param name="request"></param>
        /// <returns></returns>
        public static async Task<T> DeleteFolder<T>(DeleteFolderRequest request)
        {
            var qs = HttpUtility.ParseQueryString(string.Empty);
            qs.Add("access_token", request.Token);

            if (!string.IsNullOrEmpty(request.FolderType))
            {
                qs.Add("type", request.FolderType);
            }

            var url = request.Host + $"/rest/asset/v1/folder/{request.FolderId}/delete.json?" + qs;
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
