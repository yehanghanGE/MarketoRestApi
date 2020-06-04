using MarketoApiLibrary.Asset.Folders.Response;

namespace MarketoApiLibrary.Asset.Folders
{
    public interface IFolderController
    {
        FoldersResponse GetFolders(int rootFolderId, string rootFolderType = "Folder");
        FoldersResponse GetFolderByName(string folderName);
    }
}
