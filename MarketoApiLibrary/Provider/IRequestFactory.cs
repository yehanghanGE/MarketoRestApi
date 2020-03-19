using MarketoRestApiLibrary.Request;

namespace MarketoRestApiLibrary.Provider
{
    public interface IRequestFactory
    {
        ActivitiesExportRequest CreateActivitiesExportRequest(string host, string token);
        CustomObjectsRequest CreateCustomObjectsRequest(string host, string token);
        BaseRequest CreategetActivityTypesResult(string host, string token);
        //GetFilesRequest CreateGetFilesRequest(string host, string token);
        GetFolderByNameRequest CreateGetFolderByNameRequest(string host, string token);
        GetFoldersRequest CreateGetFoldersRequest(string host, string token);
        LeadsExportRequest CreateGetLeadsExportRequest(string host, string token);
        BaseRequest CreateGetSmartListRequest(string host, string token);
    }
}