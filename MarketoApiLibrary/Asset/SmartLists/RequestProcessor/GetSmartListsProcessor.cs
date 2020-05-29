using MarketoApiLibrary.Asset.SmartLists.Request;
using MarketoApiLibrary.Asset.SmartLists.Response;
using MarketoApiLibrary.Common.Data;
using MarketoApiLibrary.Common.Http.Services;
using MarketoApiLibrary.Common.Logging;
using MarketoApiLibrary.Common.Processor;

namespace MarketoApiLibrary.Asset.SmartLists.RequestProcessor
{
    public class GetSmartListsProcessor : MarketoHttpRequestProcessor<GetSmartListsRequest, SmartListsResponse>
    {
        public GetSmartListsProcessor(IHttpRequestProvider<GetSmartListsRequest> requestProvider,
            IMarketoDataProvider dataProvider, 
            ILoggingService<CommerceLog> commerceLogger)
            : base(requestProvider, dataProvider, commerceLogger)
        {
        }
    }
}
