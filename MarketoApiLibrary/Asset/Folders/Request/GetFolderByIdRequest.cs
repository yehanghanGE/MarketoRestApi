using MarketoApiLibrary.Request;

namespace MarketoApiLibrary.Asset.Folders.Request
{
    public class GetFolderByIdRequest: BaseRequest
    {
        public int FolderId { get; set; }
        public string FolderType { get; set; } = "Folder";
    }
}