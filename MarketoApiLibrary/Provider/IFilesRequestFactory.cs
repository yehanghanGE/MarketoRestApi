using MarketoApiLibrary.Request;

namespace MarketoApiLibrary.Provider
{
    public interface IFilesRequestFactory
    {
        GetFilesRequest CreateGetFilesRequest(string host, string token, string folderId, int offSet = 0, int maxReturn = 200);
        GetFileByNameRequest CreateGetFileByNameRequest(string host, string token, string fileName);
        GetFileByIdRequest CreateGetFileByIdRequest(string host, string token, int fileId);
    }
}