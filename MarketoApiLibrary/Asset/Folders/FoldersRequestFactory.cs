using System.Collections.Generic;
using MarketoApiLibrary.Asset.Folders.Request;

namespace MarketoApiLibrary.Asset.Folders
{
    public class FoldersRequestFactory : IFoldersRequestFactory
    {
        public GetFolderByNameRequest CreateGetFolderByNameRequest(string host, string token, string folderName,
            int parentFolderId = 0, string parentFolderType = "Folder", string type = "Folder", string workSpace = null)
        {
            var root = new Dictionary<string, dynamic> { { "id", parentFolderId }, { "type", parentFolderType } };

            var request = new GetFolderByNameRequest
            {
                Host = host,
                Token = token,
                Name = folderName, //required
                Type = type, //optional
                WorkSpace = workSpace,
                Root = parentFolderId == 0 ? null : root,
            };

            return request;
        }
        public GetFoldersRequest CreateGetFoldersRequest(string host, string token, string rootFolderId, string rootFolderType = "Folder", int offSet = 0,
            int maxDepth = 10, int maxReturn = 200, string workSpace = "")
        {
            var root = new Dictionary<string, dynamic>
            {
                {"id", rootFolderId}, {"type", rootFolderType}
            };

            var request = new GetFoldersRequest()
            {
                Host = host,
                Token = token,
                Offset = offSet,
                MaxDepth = maxDepth,
                MaxReturn = maxReturn,
                Root = root,
                WorkSpace = workSpace
            };

            return request;
        }
    }
}
