using System;
using System.Collections.Specialized;
using System.Net.Http;
using System.Threading.Tasks;
using System.Web;
using MarketoApiLibrary.Asset.Folders.Request;
using Newtonsoft.Json;

namespace MarketoApiLibrary.Asset.Folders
{
    public static class FoldersHttpProcessor
    {
        /// <summary>
        /// GET /rest/asset/v1/folders.json
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <param name="request"></param>
        /// <returns></returns>
        public static async Task<T> GetFolders<T>(GetFoldersRequest request)
        {
            var qs = HttpUtility.ParseQueryString(string.Empty);
            qs.Add("access_token", request.Token);
            qs.Add("root", JsonConvert.SerializeObject(request.Root));
            if (request.Offset > 0)
            {
                qs.Add("offset", request.Offset.ToString());
            }
            if (request.MaxDepth > 0)
            {
                qs.Add("maxDepth", request.MaxDepth.ToString());
            }
            if (request.MaxReturn > 0)
            {
                qs.Add("maxReturn", request.MaxReturn.ToString());
            }
            if (request.WorkSpace != null)
            {
                qs.Add("workSpace", request.WorkSpace);
            }
            string url = request.Host + "/rest/asset/v1/folders.json?" + qs;
            HttpClient client = new HttpClient();
            HttpResponseMessage response = await client.GetAsync(url);
            response.EnsureSuccessStatusCode();

            var result = await response.Content.ReadAsAsync<T>();
            return result;
        }
        /// <summary>
        /// GET /rest/asset/v1/folder/byName.json
        /// </summary>
        /// <param name="request"></param>
        /// <returns></returns>
        public static async Task<T> GetFolderByName<T>(GetFolderByNameRequest request)
        {
            NameValueCollection qs = HttpUtility.ParseQueryString(string.Empty);
            qs.Add("access_token", request.Token);
            qs.Add("name", request.Name);
            if (request.Type != null)
            {
                qs.Add("type", request.Type);
            }
            if (request.Root != null)
            {
                qs.Add("root", JsonConvert.SerializeObject(request.Root));
            }
            if (request.WorkSpace != null)
            {
                qs.Add("workSpace", request.WorkSpace);
            }
            string url = request.Host + "/rest/asset/v1/folder/byName.json?" + qs;
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
    }
}
