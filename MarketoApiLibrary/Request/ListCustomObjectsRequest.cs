using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MarketoRestApiLibrary.Request
{
    public class ListCustomObjectsRequest : BaseRequest
    {
        public string[] Names { get; set; }
    }
}
