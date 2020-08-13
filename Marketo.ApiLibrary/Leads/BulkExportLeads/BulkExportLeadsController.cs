using Marketo.ApiLibrary.Leads.BulkExportLeads.Request;
using Marketo.ApiLibrary.Leads.BulkExportLeads.RequestProcessor;
using Marketo.ApiLibrary.Leads.BulkExportLeads.Response;
using System.Collections.Generic;

namespace Marketo.ApiLibrary.Leads.BulkExportLeads
{
    public class BulkExportLeadsController : IBulkExportLeadsController
    {
        private readonly CreateExportLeadJobProcessor _createExportLeadJobProcessor;

        public BulkExportLeadsController(CreateExportLeadJobProcessor createExportLeadJobProcessor)
        {
            _createExportLeadJobProcessor = createExportLeadJobProcessor;
        }

        public CreateExportLeadJobResponse CreateExportLeadJob(List<string> fields, ExportLeadFilter filters, List<ColumnHeaderName> columnHeaderNames, string format = "csv")
        {
            var request = new CreateExportLeadJobRequest { Format = format, Fields = fields, Filter = filters, ColumnHeaderNames = columnHeaderNames };
            var result = _createExportLeadJobProcessor.Process(request);
            return result;
        }
    }
}
