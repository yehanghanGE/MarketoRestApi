using System.Collections.Generic;
using System.Runtime.InteropServices;
using MarketoApiLibrary.Asset.Folders.Request;
using MarketoApiLibrary.Model;

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

        public GetFoldersRequest CreateGetFoldersRequest(string host, string token, int rootFolderId, string rootFolderType = "Folder", int offSet = 0,
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

        public GetFolderByIdRequest CreateGetFolderByIdRequest(string host, string token, int folderId,
            string folderType = "Folder")
        {
            var request = new GetFolderByIdRequest()
            {
                Host = host,
                Token = token,
                FolderId = folderId,
                FolderType = folderType
            };

            return request;
        }

        public GetFolderContentsRequest CreateGetFolderContentsRequest(string host, string token, int folderId,
            string folderType = "Folder", int offSet = 0, int maxReturn = 200)
        {
            var request = new GetFolderContentsRequest()
            {
                Host = host,
                Token = token,
                FolderId = folderId,
                FolderType = folderType,
                MaxReturn = maxReturn,
                Offset = offSet
            };

            return request;
        }

        public UpdateFolderMetadataRequest CreateUpdateFolderMetadataRequest(string host, string token, int folderId,
            string folderName = null, string folderType = null, string description = null, bool isArchive = true)
        {
            var request = new UpdateFolderMetadataRequest()
            {
                Host = host,
                Token = token,
                FolderId = folderId,
                FolderName = folderName,
                FolderType = folderType,
                Description = description,
                IsArchive = isArchive
            };

            return request;
        }

        public CreateFolderRequest CreateCreateFolderRequest(string host, string token,
            string folderName, int parentFolderId, string parentFolderType,string description = null)
        {
            var parentFolder = new Folder {Id = parentFolderId, Type = parentFolderType};
            var request = new CreateFolderRequest()
            {
                Host = host,
                Token = token,
                Parent = parentFolder,
                FolderName = folderName,
                Description = description,
            };

            return request;
        }

        public DeleteFolderRequest CreateDeleteFolderRequest(string host, string token,
            int folderId, string folderType = null)
        {
            var request = new DeleteFolderRequest()
            {
                Host = host,
                Token = token,
                FolderId = folderId,
                FolderType = folderType
            };

            return request;
        }
    }
}
