using MarketoApiLibrary.Request;
using System.Collections.Generic;

namespace MarketoApiLibrary.Provider
{
    public class FilesRequestFactory: IFilesRequestFactory
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
    }
}
