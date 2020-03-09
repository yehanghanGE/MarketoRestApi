using MarketoRestApiLibrary.Request;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MarketoRestApiLibrary.Provider
{
    public static class RequestFactory
    {
        public static GetFilesRequest CreateGetFilesRequest(string host, string token)
        {
            Dictionary<string, dynamic> folder = new Dictionary<string, dynamic>();
            folder.Add("id", 29514);
            folder.Add("type", "Folder");
            var getFilesRequest = new GetFilesRequest()
            {
                Host = host,
                Token = token,
                //Offset = 10,
                //MaxReturn = 3,
                Folder = folder
            };

            return getFilesRequest;
        }
        public static GetFolderByNameRequest CreateGetFolderByNameRequest(string host, string token)
        {
            Dictionary<string, dynamic> root = new Dictionary<string, dynamic>();
            root.Add("id", 17445);
            root.Add("type", "folder");

            var getFolderByNameRequest = new GetFolderByNameRequest()
            {
                Host = host,
                Token = token,
                Name = "LATAM", //required
                //Type = "Folder",//optional
                //WorkSpace = "GL LS - Global Life Sciences",
                Root = null     //optional
            };

            return getFolderByNameRequest;
        }
        public static GetFoldersRequest CreateGetFoldersRequest(string host, string token)
        {
            Dictionary<string, dynamic> root = new Dictionary<string, dynamic>();
            root.Add("id", 17445);
            root.Add("type", "folder");

            var getFoldersRequest = new GetFoldersRequest()
            {
                Host = host,
                Token = token,
                Offset = 0,
                MaxDepth = 2,
                MaxReturn = 30,
                Root = root
                //WorkSpace = "GL LS - Global Life Sciences"
            };

            return getFoldersRequest;
        }
        public static BaseRequest CreategetActivityTypesResult(string host, string token)
        {
            var request = new BaseRequest()
            {
                Host = host,
                Token = token
            };

            return request;
        }
    }
}
