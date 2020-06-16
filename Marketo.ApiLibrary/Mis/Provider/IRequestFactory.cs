using Marketo.ApiLibrary.Asset.Files.Request;
using Marketo.ApiLibrary.Asset.Folders.Request;
using Marketo.ApiLibrary.Common.Model;
using Marketo.ApiLibrary.Mis.Request;

namespace Marketo.ApiLibrary.Mis.Provider
{
    public interface IRequestFactory
    {
        GetFilesRequest CreateGetFilesRequest(string host, string token, string folderId, int offSet = 0, int maxReturn = 200);
        ActivitiesExportRequest CreateActivitiesExportRequest(string host, string token);
        CustomObjectsRequest CreateCustomObjectsRequest(string host, string token);
        BaseRequest CreategetActivityTypesResult(string host, string token);
        //GetFilesRequest CreateGetFilesRequest(string host, string token);
        GetFolderByNameRequest CreateGetFolderByNameRequest(string host, string token);
        GetFoldersRequest CreateGetFoldersRequest(string host, string token, int rootFolderId);
        LeadsExportRequest CreateGetLeadsExportRequest(string host, string token);
        BaseRequest CreateGetSmartListRequest(string host, string token);
    }
}