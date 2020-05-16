using MarketoApiLibrary.Asset.Files.Request;
using MarketoApiLibrary.Asset.Folders.Request;
using MarketoApiLibrary.Common.Model;
using MarketoApiLibrary.Mis.Request;

namespace MarketoApiLibrary.Mis.Provider
{
    public interface IRequestFactory
    {
        GetFilesRequest CreateGetFilesRequest(string host, string token, string folderId, int offSet = 0, int maxReturn = 200);
        ActivitiesExportRequest CreateActivitiesExportRequest(string host, string token);
        CustomObjectsRequest CreateCustomObjectsRequest(string host, string token);
        BaseRequest CreategetActivityTypesResult(string host, string token);
        //GetFilesRequest CreateGetFilesRequest(string host, string token);
        GetFolderByNameRequest CreateGetFolderByNameRequest(string host, string token);
        GetFoldersRequest CreateGetFoldersRequest(string host, string token, string rootFolderId);
        LeadsExportRequest CreateGetLeadsExportRequest(string host, string token);
        BaseRequest CreateGetSmartListRequest(string host, string token);
    }
}