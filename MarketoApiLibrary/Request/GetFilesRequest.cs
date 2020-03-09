using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MarketoRestApiLibrary.Request
{
    public class GetFilesRequest: BaseRequest
    {
        
        public Dictionary<string, dynamic> Folder = new Dictionary<string, dynamic>();
        public int Offset { get; set; }   //integer offset for paging
        public int MaxReturn { get; set; }//maximum number of returned results, max 200, default 20
    }
}
