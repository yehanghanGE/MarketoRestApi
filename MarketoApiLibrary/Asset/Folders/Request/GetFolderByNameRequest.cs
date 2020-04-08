using System.Collections.Generic;
using MarketoApiLibrary.Request;

namespace MarketoApiLibrary.Asset.Folders.Request
{
    public class GetFolderByNameRequest : BaseRequest
    {
        public string Name { get; set; }
        public string Type { get; set; }
        public Dictionary<string, dynamic> Root = new Dictionary<string, dynamic>();
        public string WorkSpace { get; set; }//filter for workspace

    }
}
