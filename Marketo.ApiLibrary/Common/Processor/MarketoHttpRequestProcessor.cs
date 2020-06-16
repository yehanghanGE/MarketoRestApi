using Marketo.ApiLibrary.Common.Data;
using Marketo.ApiLibrary.Common.Http.Services;
using Marketo.ApiLibrary.Common.Http.ValueObjects;
using Marketo.ApiLibrary.Common.Logging;
using Marketo.ApiLibrary.Common.Model;
using System.Diagnostics.CodeAnalysis;

namespace Marketo.ApiLibrary.Common.Processor
{
    [ExcludeFromCodeCoverage]
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
