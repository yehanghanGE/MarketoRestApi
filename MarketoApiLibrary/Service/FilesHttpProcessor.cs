
using System.Collections.Specialized;
using System.Net.Http;
using System.Threading.Tasks;
using System.Web;
using MarketoApiLibrary.Model;
using MarketoApiLibrary.Request;
using MarketoApiLibrary.Response;
using Newtonsoft.Json;

namespace MarketoApiLibrary.Service
{
    public static class FilesHttpProcessor
    {
        public static async Task<FilesResponse> GetFiles(GetFilesRequest request)
        {
            var qs = HttpUtility.ParseQueryString(string.Empty);
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
            string url = request.Host + "/rest/asset/v1/files.json?" + qs;
            HttpClient client = new HttpClient();
            HttpResponseMessage response = await client.GetAsync(url);
            response.EnsureSuccessStatusCode();

            string content = await response.Content.ReadAsStringAsync();
            return JsonConvert.DeserializeObject<FilesResponse>(content);
        }

        public static async Task<T> GetFileByName<T>(GetFileByNameRequest request)
        {
            var qs = HttpUtility.ParseQueryString(string.Empty);
            qs.Add("access_token", request.Token);
            qs.Add("name", request.FileName);
            string url = request.Host + "/rest/asset/v1/file/byName.json?" + qs;
            var client = new HttpClient();
            var response = await client.GetAsync(url);
            response.EnsureSuccessStatusCode();

            string content = await response.Content.ReadAsStringAsync();
            return JsonConvert.DeserializeObject<T>(content);
        }
    }
}
