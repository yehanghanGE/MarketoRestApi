using MarketoApiLibrary.Asset.Folders.Request;

namespace MarketoApiLibrary.Asset.Folders
{
    public interface IFoldersRequestFactory
    {
        GetFolderByNameRequest CreateGetFolderByNameRequest(string host, string token, string folderName, int parentFolderId = 0, string parentFolderType = "Folder", string type = "Folder", string workSpace = null);
        GetFoldersRequest CreateGetFoldersRequest(string host, string token, string rootFolderId, string rootFolderType = "Folder", int offSet = 0, int maxDepth = 10, int maxReturn = 200, string workSpace = "");
    }
}