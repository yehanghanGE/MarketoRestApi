using Marketo.ApiLibrary.Common.Data;
using Marketo.ApiLibrary.Common.Http.Services;
using Marketo.ApiLibrary.Common.Logging;
using Marketo.ApiLibrary.Common.Processor;

using Marketo.ApiLibrary.Lead.Leads.Request;
using Marketo.ApiLibrary.Lead.Leads.Response;

namespace Marketo.ApiLibrary.Lead.Leads.RequestProcessor
{
    public class DescribeLeadProcessor : MarketoHttpRequestProcessor<DescribeLeadRequest, LeadAttributeResponse>
    {
        public DescribeLeadProcessor(IHttpRequestProvider<DescribeLeadRequest> requestProvider,
            IMarketoDataProvider dataProvider,
            ILoggingService<CommerceLog> commerceLogger) :
            base(requestProvider, dataProvider, commerceLogger)
        {
        }
    }
}
