using Marketo.ApiLibrary.Common.Model;
using System.Collections.Generic;

namespace Marketo.ApiLibrary.Leads.BulkExportLeads.Request
{
    public class CreateExportLeadJobRequest : BaseRequest
    {
        public List<ColumnHeaderName> ColumnHeaderNames { get; set; }
        public List<string> Fields { get; set; }
        public ExportLeadFilter Filter { get; set; }
        public string Format { get; set; }
    }
}
