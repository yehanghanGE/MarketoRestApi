using MarketoApiLibrary.Common.Http.Data;
using MarketoApiLibrary.Common.Http.Exceptions;
using MarketoApiLibrary.Common.Http.ValueObjects;
using MarketoApiLibrary.Common.Logging;
using MarketoApiLibrary.Common.Model;
using System;
using System.Net.Http;

namespace MarketoApiLibrary.Common.Data
{
    public class MarketoDataProvider : IMarketoDataProvider
    {
        private readonly IHttpApiDataProvider _apiDataProvider;

        public MarketoDataProvider(IHttpApiDataProvider apiDataProvider)
        {
            this._apiDataProvider = apiDataProvider;
        }

        public T ExecuteRequest<T>(HttpRequest request, ILoggingService<ILogInstance> logger) where T : ApiModel
        {
            var response = this._apiDataProvider.SendRequest(request, logger);
            if (!response.IsSuccessCode)
            {
                var stringContent = response.Content.ReadAsStringAsync().Result;
                throw new HttpResponseException(response.Code, stringContent);
            }

            var model = response.Content.ReadAsAsync<T>().Result;
            if (model == null)
                throw new InvalidOperationException($"Could not get the response model {typeof(T).FullName}");
            return model;
        }

        public void ExecuteRequest(HttpRequest request, ILoggingService<ILogInstance> logger)
        {
            var response = this._apiDataProvider.SendRequest(request, logger);
            if (!response.IsSuccessCode)
                throw new HttpResponseException(response.Code);
        }
    }
}
