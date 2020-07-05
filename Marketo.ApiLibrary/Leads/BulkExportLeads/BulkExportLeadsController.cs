using Marketo.ApiLibrary.Leads.BulkExportLeads.Request;
using Marketo.ApiLibrary.Leads.BulkExportLeads.RequestProcessor;
using Marketo.ApiLibrary.Leads.BulkExportLeads.Response;

namespace Marketo.ApiLibrary.Leads.BulkExportLeads
{
    public class BulkExportLeadsController : IBulkExportLeadsController
    {
        private readonly CreateExportLeadJobProcessor _createExportLeadJobProcessor;

        public BulkExportLeadsController(CreateExportLeadJobProcessor createExportLeadJobProcessor)
        {
            _createExportLeadJobProcessor = createExportLeadJobProcessor;
        }

        public CreateExportLeadJobResponse CreateExportLeadJob()
        {
            var request = new CreateExportLeadJobRequest();
            var result = _createExportLeadJobProcessor.Process(request);
            return result;
        }
    }
}
