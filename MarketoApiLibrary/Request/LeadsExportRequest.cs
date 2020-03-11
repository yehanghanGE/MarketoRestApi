using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MarketoRestApiLibrary.Request
{
    public class LeadsExportRequest : BaseRequest
    {
        public string OutputFormat { get; set; }
        public string[] Fields { get; set; }
        public string ExportId { get; set; }
        public Dictionary<string, dynamic> Filters { get; set; }
    }
}
