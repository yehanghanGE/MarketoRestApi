using MarketoApiLibrary.Asset.Folders.Request;
using MarketoApiLibrary.Asset.Folders.Response;
using MarketoApiLibrary.Common.Data;
using MarketoApiLibrary.Common.Http.Services;
using MarketoApiLibrary.Common.Logging;
using MarketoApiLibrary.Common.Processor;

namespace MarketoApiLibrary.Asset.Folders.RequestProcessor
{
    public class GetFolderByIdProcessor : MarketoHttpRequestProcessor<GetFolderByIdRequest, FoldersResponse>
    {
        public GetFolderByIdProcessor(IHttpRequestProvider<GetFolderByIdRequest> requestProvider,
            IMarketoDataProvider dataProvider,
            ILoggingService<CommerceLog> commerceLogger) : base(requestProvider, dataProvider, commerceLogger)
        {
        }
    }
}
