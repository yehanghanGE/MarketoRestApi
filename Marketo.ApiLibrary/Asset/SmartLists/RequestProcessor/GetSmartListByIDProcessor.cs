using Marketo.ApiLibrary.Asset.SmartLists.Request;
using Marketo.ApiLibrary.Asset.SmartLists.Response;
using Marketo.ApiLibrary.Common.Data;
using Marketo.ApiLibrary.Common.Http.Services;
using Marketo.ApiLibrary.Common.Logging;
using Marketo.ApiLibrary.Common.Processor;

namespace Marketo.ApiLibrary.Asset.SmartLists.RequestProcessor
{
    public class GetSmartListByIdProcessor : MarketoHttpRequestProcessor<GetSmartListByIdRequest, SmartListsResponseWithRules>
    {
        public GetSmartListByIdProcessor(IHttpRequestProvider<GetSmartListByIdRequest> requestProvider,
            IMarketoDataProvider dataProvider,
            ILoggingService<CommerceLog> commerceLogger) :
            base(requestProvider, dataProvider, commerceLogger)
        {
        }
    }
}
