using System.Collections.Generic;

namespace Marketo.ApiLibrary.Leads.BulkExportLeads.Request
{
    public class CreateExportLeadJobRequest
    {
        public ColumnHeaderNames ColumnHeaderNames { get; set; }
        public List<string> Fields { get; set; }
        public ExportLeadFilter Filter { get; set; }
        public string Format { get; set; }
    }
}
