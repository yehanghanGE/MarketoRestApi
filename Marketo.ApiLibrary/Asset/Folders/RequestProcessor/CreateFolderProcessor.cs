using Marketo.ApiLibrary.Asset.Folders.Request;
using Marketo.ApiLibrary.Asset.Folders.Response;
using Marketo.ApiLibrary.Common.Data;
using Marketo.ApiLibrary.Common.Http.Services;
using Marketo.ApiLibrary.Common.Logging;
using Marketo.ApiLibrary.Common.Processor;

namespace Marketo.ApiLibrary.Asset.Folders.RequestProcessor
{
    public class CreateFolderProcessor : MarketoHttpRequestProcessor<CreateFolderRequest, FoldersResponse>
    {
        public CreateFolderProcessor(IHttpRequestProvider<CreateFolderRequest> requestProvider,
            IMarketoDataProvider dataProvider,
            ILoggingService<CommerceLog> commerceLogger) : base(requestProvider, dataProvider, commerceLogger)
        {
        }
    }
}
