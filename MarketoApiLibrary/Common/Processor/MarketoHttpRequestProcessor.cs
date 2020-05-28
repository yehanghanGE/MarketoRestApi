using MarketoApiLibrary.Common.Data;
using MarketoApiLibrary.Common.Http.Services;
using MarketoApiLibrary.Common.Http.ValueObjects;
using MarketoApiLibrary.Common.Logging;
using MarketoApiLibrary.Common.Model;

namespace MarketoApiLibrary.Common.Processor
{
    public abstract class MarketoHttpRequestProcessor<TRequest, TDto> : BaseMarketoHttpRequestProcessor<TRequest>
        where TRequest : BaseRequest
        where TDto : ApiModel
    {
        private readonly IMarketoDataProvider _dataProvider;

        protected MarketoHttpRequestProcessor(IHttpRequestProvider<TRequest> requestProvider,
            IMarketoDataProvider dataProvider, ILoggingService<CommerceLog> commerceLogger)
            : base(requestProvider, commerceLogger)
        {
            this._dataProvider = dataProvider;
        }

        public TDto Process(BaseRequest request)
        {
            var castRequest = (TRequest)request;
            var httpRequest = this.GetHttpRequest(castRequest);
            var response = this.ExecuteRequest(httpRequest);

            return response;
        }

        protected virtual TDto ExecuteRequest(HttpRequest request)
        {
            var logger = this.GetLogger();
            return this._dataProvider.ExecuteRequest<TDto>(request, logger);
        }
    }
}
