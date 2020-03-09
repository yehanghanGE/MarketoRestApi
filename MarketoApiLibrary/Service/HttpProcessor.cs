using MarketoRestApiLibrary.Request;
using Newtonsoft.Json;
using System;
using System.IO;
using System.Net;
using System.Web;

namespace MarketoRestApiLibrary.Service
{
    public static class HttpProcessor
    {
        public static string GetFiles(GetFilesRequest getFilesRequest)
        {
            var qs = HttpUtility.ParseQueryString(string.Empty);
            qs.Add("access_token", getFilesRequest.Token);
            if (getFilesRequest.Folder != null)
            {
                qs.Add("folder", JsonConvert.SerializeObject(getFilesRequest.Folder));
            }
            if (getFilesRequest.Offset > 0)
            {
                qs.Add("offset", getFilesRequest.Offset.ToString());
            }
            if (getFilesRequest.MaxReturn > 0)
            {
                qs.Add("maxReturn", getFilesRequest.MaxReturn.ToString());
            }
            string url = getFilesRequest.Host + "/rest/asset/v1/files.json?" + qs.ToString();
            HttpWebRequest request = (HttpWebRequest)WebRequest.Create(url);
            request.ContentType = "application/json";
            request.Accept = "application/json";
            HttpWebResponse response = (HttpWebResponse)request.GetResponse();
            Stream resStream = response.GetResponseStream();
            StreamReader reader = new StreamReader(resStream);
            return reader.ReadToEnd();
        }

        public static string GetFolders(GetFoldersRequest getFoldersRequest)
        {
            var qs = HttpUtility.ParseQueryString(string.Empty);
            qs.Add("access_token", getFoldersRequest.Token);
            qs.Add("root", JsonConvert.SerializeObject(getFoldersRequest.Root));
            if (getFoldersRequest.Offset > 0)
            {
                qs.Add("offset", getFoldersRequest.Offset.ToString());
            }
            if (getFoldersRequest.MaxDepth > 0)
            {
                qs.Add("maxDepth", getFoldersRequest.MaxDepth.ToString());
            }
            if (getFoldersRequest.MaxReturn > 0)
            {
                qs.Add("maxReturn", getFoldersRequest.MaxReturn.ToString());
            }
            if (getFoldersRequest.WorkSpace != null)
            {
                qs.Add("workSpace", getFoldersRequest.WorkSpace);
            }
            String url = getFoldersRequest.Host + "/rest/asset/v1/folders.json?" + qs.ToString();
            HttpWebRequest request = (HttpWebRequest)WebRequest.Create(url);
            request.ContentType = "application/json";
            request.Accept = "application/json";
            HttpWebResponse response = (HttpWebResponse)request.GetResponse();
            Stream resStream = response.GetResponseStream();
            StreamReader reader = new StreamReader(resStream);
            return reader.ReadToEnd();
        }

        public static string GetActivityTypes(BaseRequest getActivityTypesRequest)
        {
            string url = getActivityTypesRequest.Host + "/rest/v1/activities/types.json?access_token=" + getActivityTypesRequest.Token;
            HttpWebRequest request = (HttpWebRequest)WebRequest.Create(url);
            request.ContentType = "application/json";
            request.Accept = "application/json";
            HttpWebResponse response = (HttpWebResponse)request.GetResponse();
            Stream resStream = response.GetResponseStream();
            StreamReader reader = new StreamReader(resStream);
            return reader.ReadToEnd();
        }

        public static string ListCustomObjects(ListCustomObjectsRequest listCustomObjectsRequest)
        {
            var qs = HttpUtility.ParseQueryString(string.Empty);
            qs.Add("access_token", listCustomObjectsRequest.Token);
            if (listCustomObjectsRequest.Names != null)
            {
                qs.Add("names", Helper.CsvString(listCustomObjectsRequest.Names));
            }
            String url = listCustomObjectsRequest.Host + "/rest/v1/customobjects.json?" + qs.ToString();
            HttpWebRequest request = (HttpWebRequest)WebRequest.Create(url);
            request.ContentType = "application/json";
            request.Accept = "application/json";
            HttpWebResponse response = (HttpWebResponse)request.GetResponse();
            Stream resStream = response.GetResponseStream();
            StreamReader reader = new StreamReader(resStream);
            return reader.ReadToEnd();
        }

        public static string GetFolderByName(GetFolderByNameRequest getFolderByNameRequest)
        {

            var qs = HttpUtility.ParseQueryString(string.Empty);
            qs.Add("access_token", getFolderByNameRequest.Token);
            qs.Add("name", getFolderByNameRequest.Name);
            if (getFolderByNameRequest.Type != null)
            {
                qs.Add("type", getFolderByNameRequest.Type);
            }
            if (getFolderByNameRequest.Root != null)
            {
                qs.Add("root", JsonConvert.SerializeObject(getFolderByNameRequest.Root));
            }
            if (getFolderByNameRequest.WorkSpace != null)
            {
                qs.Add("workSpace", getFolderByNameRequest.WorkSpace);
            }
            String url = getFolderByNameRequest.Host + "/rest/asset/v1/folder/byName.json?" + qs.ToString();
            Console.Write(url);
            HttpWebRequest request = (HttpWebRequest)WebRequest.Create(url);
            request.ContentType = "application/json";
            request.Accept = "application/json";
            HttpWebResponse response = (HttpWebResponse)request.GetResponse();
            Stream resStream = response.GetResponseStream();
            StreamReader reader = new StreamReader(resStream);
            return reader.ReadToEnd();
        }
    }
}
