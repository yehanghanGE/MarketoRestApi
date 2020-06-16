using Marketo.ApiLibrary.Common.Model;
using Marketo.ApiLibrary.Mis.Request;

namespace Marketo.ApiLibrary.Asset.Folders.Request
{
    public class CreateFolderRequest: BaseRequest
    {
        public string FolderName  { get; set; }
        public string Description { get; set; }
        public Folder Parent { get; set; }
        
    }
}