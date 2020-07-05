using Marketo.ApiLibrary.Common.Data;
using Marketo.ApiLibrary.Common.Http.Services;
using Marketo.ApiLibrary.Common.Logging;
using Marketo.ApiLibrary.Common.Processor;
using Marketo.ApiLibrary.Leads.BulkExportLeads.Request;
using Marketo.ApiLibrary.Leads.BulkExportLeads.Response;

namespace Marketo.ApiLibrary.Leads.BulkExportLeads.RequestProcessor
{
    public class CreateExportLeadJobProcessor : MarketoHttpRequestProcessor<CreateExportLeadJobRequest, CreateExportLeadJobResponse>
    {
        public CreateExportLeadJobProcessor(IHttpRequestProvider<CreateExportLeadJobRequest> requestProvider,
            IMarketoDataProvider dataProvider,
            ILoggingService<CommerceLog> commerceLogger) :
            base(requestProvider, dataProvider, commerceLogger)
        {
        }
    }
}
