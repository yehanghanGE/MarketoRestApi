using MarketoApiLibrary.Asset.Folders.Request;
using MarketoApiLibrary.Asset.Folders.Response;
using MarketoApiLibrary.Common.Data;
using MarketoApiLibrary.Common.Http.Services;
using MarketoApiLibrary.Common.Logging;
using MarketoApiLibrary.Common.Processor;

namespace MarketoApiLibrary.Asset.Folders.RequestProcessor
{
    public class DeleteFolderProcessor : MarketoHttpRequestProcessor<DeleteFolderRequest, FolderDeleteResponse>
    {
        public DeleteFolderProcessor(IHttpRequestProvider<DeleteFolderRequest> requestProvider,
            IMarketoDataProvider dataProvider,
            ILoggingService<CommerceLog> commerceLogger) : base(requestProvider, dataProvider, commerceLogger)
        {
        }
    }
}
