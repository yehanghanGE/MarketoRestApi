using System;
using System.Net.Http;
using MarketoApiLibrary.Http.Exceptions;
using MarketoApiLibrary.Http.Services;
using MarketoApiLibrary.Http.ValueObjects;

namespace MarketoApiLibrary.Http.Data
{
    public class HttpApiDataProvider
    {
        private readonly IHttpClientFactory httpClientFactory;

        public HttpApiDataProvider(IHttpClientFactory httpClientFactory)
        {
            //Assert.ArgumentNotNull(httpClientFactory, nameof(httpClientFactory));

            this.httpClientFactory = httpClientFactory;
        }

        public HttpResponse SendRequest(HttpRequest request, Func<HttpResponse, HttpResponse> errorHandler = null)
        {
            //Assert.ArgumentNotNull(request, nameof(request));
            //Assert.ArgumentNotNull(logger, nameof(logger));

            var result = this.ProcessRequest(request);

            var response = new HttpResponse
            {
                Content = result.Content,
                Code = result.StatusCode,
                IsSuccessCode = result.IsSuccessStatusCode
            };

            if (response.IsSuccessCode)
                return response;

            //this.Log(logger, LogNotificationLevel.Error, $"[{this}.{nameof(this.SendRequest)}]:Request {request.Uri} failed {response.Code}");

            if (errorHandler != null)
                return errorHandler(response);

            var responseMessage = response.Content.ReadAsStringAsync().Result;
            throw new HttpResponseException(response.Code, responseMessage);

        }

        private HttpResponseMessage ProcessRequest(HttpRequest request)
        {
            var message = new HttpRequestMessage
            {
                Method = request.Method,
                Content = request.Body,
                RequestUri = request.Uri,
                Headers = { Authorization = request.Authentication }
            };
            var serializedRequest = this.SerializeRequest(message);

            try
            {
                //this.Log(logger, LogNotificationLevel.Info, $"[{this}.{nameof(this.ProcessRequest)}]: sending request {serializedRequest}");

                return this.SendMessage(message, request.Timeout);
            }
            catch (HttpRequestException e)
            {
                //this.Log(logger, LogNotificationLevel.Warning, $"[{this}.{nameof(this.ProcessRequest)}]: error while sending request {serializedRequest}", e);
            }

            try
            {
                //this.Log(logger, LogNotificationLevel.Info, $"[{this}.{nameof(this.ProcessRequest)}]: retry send request {serializedRequest}");

                return this.SendMessage(message, request.Timeout);
            }
            catch (HttpRequestException e)
            {
                //this.Log(logger, LogNotificationLevel.Error, $"[{this}.{nameof(this.ProcessRequest)}]: error while retrying request {serializedRequest}", e);
                throw;
            }
        }

        private HttpResponseMessage SendMessage(HttpRequestMessage message, int? timeout)
        {
            var httpClient = timeout.HasValue
                ? this.httpClientFactory.GetHttpClient(message.RequestUri, timeout.Value)
                : this.httpClientFactory.GetHttpClient(message.RequestUri);
            var task = httpClient.SendAsync(message);
            return task.Result;
        }

        //private void Log(ILoggingService<ILogInstance> logger, LogNotificationLevel logLevel, string message, Exception exception = null)
        //{
        //    switch (logLevel)
        //    {
        //        case LogNotificationLevel.Info:
        //            logger.Info(message);
        //            break;
        //        case LogNotificationLevel.Warning:
        //            logger.Warn(message, exception);
        //            break;
        //        case LogNotificationLevel.Error:
        //            if (exception != null)
        //                logger.Error(message, exception);
        //            else
        //                logger.Error(message);
        //            break;
        //    }
        //}

        private string SerializeRequest(HttpRequestMessage request)
        {
            var requestPart = $"Method: {request.Method}, RequestUri: {request.RequestUri.AbsoluteUri}";
            var json = request.Content?.ReadAsStringAsync().Result ?? string.Empty;
            if (string.IsNullOrEmpty(json))
                return requestPart;

            return $"{requestPart}, Content: {json}";
        }
    }
}
