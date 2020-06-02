using MarketoApiLibrary.Common.Model;

namespace MarketoApiLibrary.Asset.Folders.Request
{
    public class GetFoldersRequest : BaseRequest
    {
        public Folder Root { get; set; }
        public int Offset { get; set; }//integer offset for paging
        public int MaxDepth { get; set; }//depth of tree to traverse, default 2
        public int MaxReturn { get; set; }//maximum number of returned results, max 200, default 20
        public string WorkSpace { get; set; }//filter for workspace
    }
}
