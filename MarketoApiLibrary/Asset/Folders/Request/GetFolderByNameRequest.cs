using MarketoApiLibrary.Common.Model;

namespace MarketoApiLibrary.Asset.Folders.Request
{
    public class GetFolderByNameRequest : BaseRequest
    {
        public string Name { get; set; }
        public string Type { get; set; }
        public Folder Root { get; set; }
        public string WorkSpace { get; set; }//filter for workspace
    }
}
