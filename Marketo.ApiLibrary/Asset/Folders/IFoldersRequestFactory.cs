using Marketo.ApiLibrary.Asset.Folders.Request;

namespace Marketo.ApiLibrary.Asset.Folders
{
    public interface IFoldersRequestFactory
    {
        GetFolderByNameRequest CreateGetFolderByNameRequest(string host, string token, string folderName, int parentFolderId = 0, string parentFolderType = "Folder", string type = "Folder", string workSpace = null);
        GetFoldersRequest CreateGetFoldersRequest(string host, string token, int rootFolderId, string rootFolderType = "Folder", int offSet = 0, int maxDepth = 10, int maxReturn = 200, string workSpace = null);
        GetFolderByIdRequest CreateGetFolderByIdRequest(string host, string token, int folderId, string folderType = "Folder");
        GetFolderContentsRequest CreateGetFolderContentsRequest(string host, string token, int folderId, string folderType = "Folder", int offSet = 0, int maxReturn = 200);
        UpdateFolderMetadataRequest CreateUpdateFolderMetadataRequest(string host, string token,int folderId, string folderName = null, string folderType =null, string description = null, bool isArchive = false);
        CreateFolderRequest CreateCreateFolderRequest(string host, string token,
            string folderName, int parentFolderId, string parentFolderType, string description = null);
        DeleteFolderRequest CreateDeleteFolderRequest(string host, string token,
            int folderId, string folderType = null);
    }
}