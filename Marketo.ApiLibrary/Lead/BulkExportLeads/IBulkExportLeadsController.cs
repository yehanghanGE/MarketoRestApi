using Marketo.ApiLibrary.Lead.BulkExportLeads.Request;
using Marketo.ApiLibrary.Lead.BulkExportLeads.Response;
using System.Collections.Generic;

namespace Marketo.ApiLibrary.Lead.BulkExportLeads
{
    public interface IBulkExportLeadsController
    {
        CreateExportLeadJobResponse CreateExportLeadJob(List<string> fields, ExportLeadFilter filters, List<ColumnHeaderName> columnHeaderNames, string format = "csv");
    }
}
