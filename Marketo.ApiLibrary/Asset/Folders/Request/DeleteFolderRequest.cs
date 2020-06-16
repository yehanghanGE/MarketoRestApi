using Marketo.ApiLibrary.Common.Model;

namespace Marketo.ApiLibrary.Asset.Folders.Request
{
    public class DeleteFolderRequest : BaseRequest
    {
        public int FolderId { get; set; }
        public string FolderType { get; set; } = "Folder";
    }
}