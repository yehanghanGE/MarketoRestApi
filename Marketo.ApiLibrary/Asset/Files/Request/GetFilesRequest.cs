using System.Collections.Generic;
using Marketo.ApiLibrary.Common.Model;
using Marketo.ApiLibrary.Mis.Request;

namespace Marketo.ApiLibrary.Asset.Files.Request
{
    public class GetFilesRequest : BaseRequest
    {
        public Dictionary<string, dynamic> Folder = new Dictionary<string, dynamic>();
        public int Offset { get; set; }   //integer offset for paging
        public int MaxReturn { get; set; }//maximum number of returned results, max 200, default 20
    }
}
