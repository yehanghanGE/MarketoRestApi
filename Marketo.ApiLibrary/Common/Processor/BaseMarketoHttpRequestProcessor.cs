using Marketo.ApiLibrary.Common.Http.Services;
using Marketo.ApiLibrary.Common.Http.ValueObjects;
using Marketo.ApiLibrary.Common.Logging;
using Marketo.ApiLibrary.Common.Model;
using System.Diagnostics.CodeAnalysis;

namespace Marketo.ApiLibrary.Common.Processor
{
    [ExcludeFromCodeCoverage]
    public abstract class BaseMarketoHttpRequestProcessor<TRequest>
        where TRequest : BaseRequest
    {
        private readonly IHttpRequestProvider<TRequest> _requestProvider;
        protected readonly ILoggingService<CommerceLog> CommerceLogger;

        protected BaseMarketoHttpRequestProcessor(IHttpRequestProvider<TRequest> requestProvider, ILoggingService<CommerceLog> commerceLogger)
        {
            this._requestProvider = requestProvider;
            this.CommerceLogger = commerceLogger;
        }

        protected virtual HttpRequest GetHttpRequest(TRequest request)
        {
            return this._requestProvider.GetRequest(request);
        }

        protected virtual ILoggingService<ILogInstance> GetLogger()
        {
            return this.CommerceLogger;
        }
    }
}
