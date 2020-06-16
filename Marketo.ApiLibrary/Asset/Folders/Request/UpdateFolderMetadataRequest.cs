using Marketo.ApiLibrary.Common.Model;
using Marketo.ApiLibrary.Mis.Request;

namespace Marketo.ApiLibrary.Asset.Folders.Request
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