using System.Collections.Generic;
using MarketoApiLibrary.Asset.Files.Request;
using MarketoApiLibrary.Common.Model;

namespace MarketoApiLibrary.Asset.Files
{
    public class FilesRequestFactory : IFilesRequestFactory
    {
        public GetFilesRequest CreateGetFilesRequest(string host, string token, string folderId, int offSet = 0, int maxReturn = 200)
        {
            var folder = new Dictionary<string, dynamic> { { "id", folderId }, { "type", "Folder" } };
            var getFilesRequest = new GetFilesRequest()
            {
                Host = host,
                Token = token,
                Offset = offSet,
                MaxReturn = maxReturn,
                Folder = folder
            };
            return getFilesRequest;
        }

        public GetFileByNameRequest CreateGetFileByNameRequest(string host, string token, string fileName)
        {
            var getFileByNameRequest = new GetFileByNameRequest()
            {
                Host = host,
                Token = token,
                FileName = fileName
            };
            return getFileByNameRequest;
        }

        public GetFileByIdRequest CreateGetFileByIdRequest(string host, string token, int fileId)
        {
            var request = new GetFileByIdRequest()
            {
                Host = host,
                Token = token,
                FileId = fileId.ToString()
            };
            return request;
        }

        public CreateFileRequest CreateCreateFileRequest(string host, string token, string filePath)
        {
            var request = new CreateFileRequest()
            {
                Host = host,
                Token = token,
                FilePath = filePath,
                Folder = new Folder()
                {
                    Id = 1,
                    Type = "Folder"
                }
            };
            return request;
        }

        public UpdateFileRequest CreateUpdateFileRequest(string host, string token, string filePath, string fileId)
        {
            var request = new UpdateFileRequest()
            {
                Host = host,
                Token = token,
                FilePath = filePath,
                FileId = fileId
            };

            return request;
        }
    }
}
