using System.Security.Permissions;
using MarketoApiLibrary.Common.Model;
using MarketoApiLibrary.Mis.Request;

namespace MarketoApiLibrary.Asset.Folders.Request
{
    public class DeleteFolderRequest: BaseRequest
    {
        public int FolderId { get; set; }
        public string FolderType { get; set; } = "Folder";
    }
}