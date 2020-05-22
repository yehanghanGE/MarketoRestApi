using MarketoApiLibrary.Asset.SmartLists.Request;
using MarketoApiLibrary.Asset.SmartLists.Response;
using MarketoApiLibrary.Common.Data;
using MarketoApiLibrary.Common.Http.Services;
using MarketoApiLibrary.Common.Logging;
using MarketoApiLibrary.Common.Processor;

namespace MarketoApiLibrary.Asset.SmartLists.RequestProcessor
{
    public class GetSmartListByNameProcessor : MarketoHttpRequestProcessor<GetSmartListByNameRequest, SmartListsResponse>
    {
        public GetSmartListByNameProcessor(
            IHttpRequestProvider<GetSmartListByNameRequest> requestProvider,
            IMarketoDataProvider dataProvider,
            ILoggingService<CommerceLog> commerceLogger,
            ILoggingService<SynchronizationLog> syncLogger) :
            base(requestProvider, dataProvider, commerceLogger, syncLogger)
        {
        }
    }
}
