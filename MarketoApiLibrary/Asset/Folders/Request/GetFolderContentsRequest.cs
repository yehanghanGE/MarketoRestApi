using MarketoApiLibrary.Common.Model;

namespace MarketoApiLibrary.Asset.Folders.Request
{
    public class GetFolderContentsRequest : BaseRequest
    {
        public int FolderId { get; set; }
        public int Offset { get; set; }
        public int MaxReturn { get; set; }
        public string FolderType { get; set; }
    }
}
