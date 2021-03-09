using Marketo.ApiLibrary.Lead.BulkExportLeads.Request;
using Marketo.ApiLibrary.Lead.BulkExportLeads.Response;
using System.Collections.Generic;
using Marketo.ApiLibrary.Lead.BulkExportLeads.RequestProcessor;
using static Marketo.ApiLibrary.Lead.BulkExportLeads.RequestProcessor.CreateExportLeadJobProcessor;

namespace Marketo.ApiLibrary.Lead.BulkExportLeads
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
