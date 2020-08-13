using Marketo.ApiLibrary.Leads.BulkExportLeads.Request;
using Marketo.ApiLibrary.Leads.BulkExportLeads.Response;
using System.Collections.Generic;

namespace Marketo.ApiLibrary.Leads.BulkExportLeads
{
    public interface IBulkExportLeadsController
    {
        CreateExportLeadJobResponse CreateExportLeadJob(List<string> fields, ExportLeadFilter filters, List<ColumnHeaderName> columnHeaderNames, string format = "csv");
    }
}
