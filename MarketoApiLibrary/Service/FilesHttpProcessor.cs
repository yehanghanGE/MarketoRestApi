﻿using MarketoApiLibrary.Request;
using Newtonsoft.Json;
using System.IO;
using System.Net.Http;
using System.Net.Http.Headers;
using System.Threading.Tasks;
using System.Web;

namespace MarketoApiLibrary.Service
{
    public static class FilesHttpProcessor
    {
        public static async Task<T> GetFiles<T>(GetFilesRequest request)
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

            var content = await response.Content.ReadAsAsync<T>();
            return content;
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

            var content = await response.Content.ReadAsAsync<T>();
            return content;
        }

        public static async Task<T> GetFileById<T>(GetFileByIdRequest request)
        {
            var qs = HttpUtility.ParseQueryString(string.Empty);
            qs.Add("access_token", request.Token);

            var url = request.Host + "/rest/asset/v1/file/" + request.FileId + ".json?" + qs;
            var client = new HttpClient();
            var response = await client.GetAsync(url);
            response.EnsureSuccessStatusCode();

            var content = await response.Content.ReadAsAsync<T>();
            return content;
        }
        /// <summary>
        /// POST /rest/asset/v1/files.json
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <param name="request"></param>
        /// <returns></returns>
        public static async Task<T> CreateFile<T>(CreateFileRequest request)
        {
            var qs = HttpUtility.ParseQueryString(string.Empty);
            qs.Add("access_token", request.Token);

            var url = request.Host + "/rest/asset/v1/files.json?" + qs;
            var client = new HttpClient();
            using (var form = new MultipartFormDataContent())
            {
                using (var fs = File.OpenRead(request.FilePath))
                {
                    using (var streamContent = new StreamContent(fs))
                    {
                        using (var fileContent = new ByteArrayContent(await streamContent.ReadAsByteArrayAsync()))
                        {
                            fileContent.Headers.ContentType = MediaTypeHeaderValue.Parse("multipart/form-data");

                            // "file" parameter name should be the same as the server side input parameter name
                            form.Add(fileContent, "file", Path.GetFileName(request.FilePath));
                            HttpResponseMessage response = await client.PostAsync(url, form);
                            response.EnsureSuccessStatusCode();

                            var content = await response.Content.ReadAsAsync<T>();
                            return content;
                        }
                    }
                }
            }
        }
    }
}
