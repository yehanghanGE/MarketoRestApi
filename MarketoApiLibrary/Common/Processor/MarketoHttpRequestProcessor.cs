using MarketoApiLibrary.Common.Data;
using MarketoApiLibrary.Common.Http.Services;
using MarketoApiLibrary.Common.Http.ValueObjects;
using MarketoApiLibrary.Common.Logging;
using MarketoApiLibrary.Common.Model;
using MarketoApiLibrary.Common.Services;

namespace MarketoApiLibrary.Common.Processor
{
    public abstract class MarketoHttpRequestProcessor<TRequest, TResponse, TDto, TEntity> : BaseMarketoHttpRequestProcessor<TRequest>
        where TRequest : BaseRequest
        where TResponse : ApiModel
        where TDto : ApiModel
        where TEntity : ApiModel
    {
        private readonly IEntityMapperService _entityMapperService;
        private readonly IMarketoDataProvider _dataProvider;

        protected MarketoHttpRequestProcessor(IEntityMapperService entityMapperService, IHttpRequestProvider<TRequest> requestProvider,
            IMarketoDataProvider dataProvider, ILoggingService<CommerceLog> commerceLogger, ILoggingService<SynchronizationLog> syncLogger)
            : base(requestProvider, commerceLogger, syncLogger)
        {
            this._entityMapperService = entityMapperService;
            this._dataProvider = dataProvider;
        }

        protected MarketoHttpRequestProcessor()
        {
            throw new System.NotImplementedException();
        }

        public TDto Process(BaseRequest request)
        {
            var castRequest = (TRequest)request;

            var httpRequest = this.GetHttpRequest(castRequest);
            var response = this.ExecuteRequest(httpRequest);
            //var entity = this.ReadResponse(response);

            return response;
        }

        protected virtual TDto ExecuteRequest(HttpRequest request)
        {
            var logger = this.GetLogger();
            return this._dataProvider.ExecuteRequest<TDto>(request, logger);
        }

        protected virtual TResponse ReadResponse(TDto response)
        {
            return this._entityMapperService.ReadResponse<TDto, TResponse>(response);
        }
    }
}
