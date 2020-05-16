using System.Collections.Generic;
using MarketoApiLibrary.Common.Model;

namespace MarketoApiLibrary.Mis.Request
{
    public class LeadsExportRequest : BaseRequest
    {
        public string OutputFormat { get; set; }
        public string[] Fields { get; set; }
        public string ExportId { get; set; }
        public Dictionary<string, dynamic> Filters { get; set; }
    }
}
