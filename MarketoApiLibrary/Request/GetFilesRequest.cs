using MarketoApiLibrary.Request;
using System.Collections.Generic;

namespace MarketoRestApiLibrary.Request
{
    public class GetFilesRequest : BaseRequest
    {
        public Dictionary<string, dynamic> Folder = new Dictionary<string, dynamic>();
        public int Offset { get; set; }   //integer offset for paging
        public int MaxReturn { get; set; }//maximum number of returned results, max 200, default 20
    }
}
