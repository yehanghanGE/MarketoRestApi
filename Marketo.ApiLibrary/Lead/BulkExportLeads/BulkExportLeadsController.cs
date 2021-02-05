using Marketo.ApiLibrary.Lead.BulkExportLeads.Request;
using Marketo.ApiLibrary.Lead.BulkExportLeads.RequestProcessor;
using Marketo.ApiLibrary.Lead.BulkExportLeads.Response;
using System.Collections.Generic;

namespace Marketo.ApiLibrary.Lead.BulkExportLeads
{
    public class BulkExportLeadsController : IBulkExportLeadsController
    {
        private readonly DescribeLeadProcessor _createExportLeadJobProcessor;

        public BulkExportLeadsController(DescribeLeadProcessor createExportLeadJobProcessor)
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
