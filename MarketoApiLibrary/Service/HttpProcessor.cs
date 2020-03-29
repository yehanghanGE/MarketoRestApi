﻿
using MarketoApiLibrary.Model;
using MarketoApiLibrary.Request;
using Newtonsoft.Json;
using System.Net.Http;
using System.Threading.Tasks;
using System.Web;

namespace MarketoApiLibrary.Service
{
    public static class HttpProcessor
    {
        public static async Task<GetFilesResponse> GetFiles(GetFilesRequest request)
        {
            System.Collections.Specialized.NameValueCollection qs = HttpUtility.ParseQueryString(string.Empty);
            qs.Add("access_token", request.Token);
            if (request.Folder != null)
            {
                qs.Add("folder", JsonConvert.SerializeObject(request.Folder));
            }
            if (request.Offset > 0)
            {
                qs.Add("offset", request.Offset.ToString());
            }
            if (request.MaxReturn > 0)
            {
                qs.Add("maxReturn", request.MaxReturn.ToString());
            }
            string url = request.Host + "/rest/asset/v1/files.json?" + qs.ToString();
            HttpClient client = new HttpClient();
            HttpResponseMessage response = await client.GetAsync(url);
            response.EnsureSuccessStatusCode();

            string content = await response.Content.ReadAsStringAsync();
            return JsonConvert.DeserializeObject<GetFilesResponse>(content);
        }

        public static async Task<GetFoldersResponse> GetFolders(GetFoldersRequest request)
        {
            System.Collections.Specialized.NameValueCollection qs = HttpUtility.ParseQueryString(string.Empty);
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
            string url = request.Host + "/rest/asset/v1/folders.json?" + qs.ToString();
            HttpClient client = new HttpClient();
            HttpResponseMessage response = await client.GetAsync(url);
            response.EnsureSuccessStatusCode();

            string content = await response.Content.ReadAsStringAsync();
            return JsonConvert.DeserializeObject<GetFoldersResponse>(content);
        }

        public static async Task<string> GetActivityTypes(BaseRequest request)
        {
            string url = request.Host + "/rest/v1/activities/types.json?access_token=" + request.Token;
            HttpClient client = new HttpClient();
            HttpResponseMessage response = await client.GetAsync(url);
            response.EnsureSuccessStatusCode();

            string content = await response.Content.ReadAsStringAsync();
            return content;
        }

        public static async Task<string> GetFolderByName(GetFolderByNameRequest request)
        {
            System.Collections.Specialized.NameValueCollection qs = HttpUtility.ParseQueryString(string.Empty);
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
            string url = request.Host + "/rest/asset/v1/folder/byName.json?" + qs.ToString();
            HttpClient client = new HttpClient();
            HttpResponseMessage response = await client.GetAsync(url);
            response.EnsureSuccessStatusCode();

            string content = await response.Content.ReadAsStringAsync();
            return content;
        }

        public static async Task<string> GetSmartList(BaseRequest request)
        {
            string url = request.Host + "/rest/asset/v1/staticLists.json?access_token=" + request.Token;

            HttpClient client = new HttpClient();
            HttpResponseMessage response = await client.GetAsync(url);
            response.EnsureSuccessStatusCode();

            string content = await response.Content.ReadAsStringAsync();
            return content;
        }
    }
}
