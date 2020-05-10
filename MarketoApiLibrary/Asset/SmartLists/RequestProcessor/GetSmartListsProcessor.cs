using MarketoApiLibrary.Asset.SmartLists.Request;
using MarketoApiLibrary.Asset.SmartLists.Response;
using MarketoApiLibrary.Common.Data;
using MarketoApiLibrary.Common.Http.Services;
using MarketoApiLibrary.Common.Logging;
using MarketoApiLibrary.Common.Model;
using MarketoApiLibrary.Common.Processor;
using MarketoApiLibrary.Common.Services;

namespace MarketoApiLibrary.Asset.SmartLists.RequestProcessor
{
    public class GetSmartListsProcessor : MarketoHttpRequestProcessor<GetSmartListsRequest, SmartListResponseWithRules, SmartListResponseWithRules, ApiModel>
    {
        public GetSmartListsProcessor(IEntityMapperService entityMapperService, IHttpRequestProvider<GetSmartListsRequest> requestProvider,
            IMarketoDataProvider dataProvider, ILoggingService<CommerceLog> commerceLogger, ILoggingService<SynchronizationLog> syncLogger)
            : base(entityMapperService, requestProvider, dataProvider, commerceLogger, syncLogger)
        {
        }

        public GetSmartListsProcessor()
        {
            
        }
    }
}
