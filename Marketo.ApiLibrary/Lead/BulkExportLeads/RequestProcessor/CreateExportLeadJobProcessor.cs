using Marketo.ApiLibrary.Common.Data;
using Marketo.ApiLibrary.Common.Http.Services;
using Marketo.ApiLibrary.Common.Logging;
using Marketo.ApiLibrary.Common.Processor;
using Marketo.ApiLibrary.Lead.BulkExportLeads.Request;
using Marketo.ApiLibrary.Lead.BulkExportLeads.Response;

namespace Marketo.ApiLibrary.Lead.BulkExportLeads.RequestProcessor
{
    public class CreateExportLeadJobProcessor : MarketoHttpRequestProcessor<CreateExportLeadJobRequest, CreateExportLeadJobResponse>
    {
        public CreateExportLeadJobProcessor(IHttpRequestProvider<CreateExportLeadJobRequest> requestProvider, 
            IMarketoDataProvider dataProvider, ILoggingService<CommerceLog> commerceLogger) : 
            base(requestProvider, dataProvider, commerceLogger)
        {
        }
    }
}