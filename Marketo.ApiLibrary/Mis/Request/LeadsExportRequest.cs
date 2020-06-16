using System.Collections.Generic;
using Marketo.ApiLibrary.Common.Model;

namespace Marketo.ApiLibrary.Mis.Request
{
    public class LeadsExportRequest : BaseRequest
    {
        public string OutputFormat { get; set; }
        public string[] Fields { get; set; }
        public string ExportId { get; set; }
        public Dictionary<string, dynamic> Filters { get; set; }
    }
}
