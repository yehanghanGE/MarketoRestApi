using MarketoApiLibrary.Common.Http.Data;
using MarketoApiLibrary.Common.Http.Exceptions;
using MarketoApiLibrary.Common.Http.ValueObjects;
using MarketoApiLibrary.Common.Logging;
using MarketoApiLibrary.Common.Services;
using Newtonsoft.Json;
using System;
using MarketoApiLibrary.Common.Model;

namespace MarketoApiLibrary.Common.Data
{
    public class MarketoDataProvider : IMarketoDataProvider
    {
        private readonly IHttpApiDataProvider _apiDataProvider;
        private readonly IApiModelFactory _modelFactory;

        public MarketoDataProvider(IHttpApiDataProvider apiDataProvider, IApiModelFactory modelFactory)
        {
            //Assert.ArgumentNotNull(apiDataProvider, nameof(apiDataProvider));
            //Assert.ArgumentNotNull(modelFactory, nameof(modelFactory));

            this._apiDataProvider = apiDataProvider;
            this._modelFactory = modelFactory;
        }

        public T ExecuteRequest<T>(HttpRequest request, ILoggingService<ILogInstance> logger) where T : ApiModel
        {
            //Assert.ArgumentNotNull(request, nameof(request));
            //Assert.ArgumentNotNull(logger, nameof(logger));

            var response = this._apiDataProvider.SendRequest(request, logger);
            var stringContent = response.Content.ReadAsStringAsync().Result;
            if (!response.IsSuccessCode)
                throw new HttpResponseException(response.Code, stringContent);

            var model = this._modelFactory.GetApiModel<T>();
            if (model == null)
                throw new InvalidOperationException($"Could not get api model {typeof(T).FullName}");

            JsonConvert.PopulateObject(stringContent, model);
            return model;
        }

        public void ExecuteRequest(HttpRequest request, ILoggingService<ILogInstance> logger)
        {
            //Assert.ArgumentNotNull(request, nameof(request));
            //Assert.ArgumentNotNull(logger, nameof(logger));

            var response = this._apiDataProvider.SendRequest(request, logger);
            if (!response.IsSuccessCode)
                throw new HttpResponseException(response.Code);
        }
    }
}
