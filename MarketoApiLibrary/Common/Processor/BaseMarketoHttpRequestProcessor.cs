using MarketoApiLibrary.Common.Http.Services;
using MarketoApiLibrary.Common.Http.ValueObjects;
using MarketoApiLibrary.Common.Logging;
using MarketoApiLibrary.Common.Model;

namespace MarketoApiLibrary.Common.Processor
{
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
