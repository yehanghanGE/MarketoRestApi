using System.Collections.Generic;
using MarketoApiLibrary.Request;

namespace MarketoApiLibrary.Asset.Folders.Request
{
    public class GetFolderContentsRequest : BaseRequest
    {
        public int FolderId { get; set; }
        public int Offset { get; set; }//integer offset for paging
        public int MaxReturn { get; set; }//maximum number of returned results, max 200, default 20
        public string FolderType { get; set; }//filter for workspace
    }
}
