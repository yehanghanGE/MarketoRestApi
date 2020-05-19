using MarketoApiLibrary.Common.Model;
using MarketoApiLibrary.Mis.Request;

namespace MarketoApiLibrary.Asset.Folders.Request
{
    public class CreateFolderRequest: BaseRequest
    {
        public string FolderName  { get; set; }
        public string Description { get; set; }
        public Folder Parent { get; set; }
        
    }
}