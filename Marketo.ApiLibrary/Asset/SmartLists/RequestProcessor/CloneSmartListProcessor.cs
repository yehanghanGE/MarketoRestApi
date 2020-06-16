using Marketo.ApiLibrary.Asset.SmartLists.Request;
using Marketo.ApiLibrary.Asset.SmartLists.Response;
using Marketo.ApiLibrary.Common.Data;
using Marketo.ApiLibrary.Common.Http.Services;
using Marketo.ApiLibrary.Common.Logging;
using Marketo.ApiLibrary.Common.Processor;

namespace Marketo.ApiLibrary.Asset.SmartLists.RequestProcessor
{
    public class CloneSmartListProcessor : MarketoHttpRequestProcessor<CloneSmartListRequest, SmartListsResponse>
    {
        public CloneSmartListProcessor(
            IHttpRequestProvider<CloneSmartListRequest> requestProvider,
            IMarketoDataProvider dataProvider,
            ILoggingService<CommerceLog> commerceLogger) :
            base(requestProvider, dataProvider, commerceLogger)
        {
        }
    }
}
