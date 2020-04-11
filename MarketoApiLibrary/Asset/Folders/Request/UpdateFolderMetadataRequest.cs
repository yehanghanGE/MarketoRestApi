using MarketoApiLibrary.Request;

namespace MarketoApiLibrary.Asset.Folders.Request
{
    public class UpdateFolderMetadataRequest : BaseRequest
    {
        public int FolderId { get; set; }
        public string FolderName { get; set; }
        public string FolderType { get; set; } = "Folder";
        public string Description { get; set; }
        public bool IsArchive { get; set; }
    }
}