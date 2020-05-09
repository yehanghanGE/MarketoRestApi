namespace MarketoApiLibrary.Services
{
    using System;
    using System.Net.Http;
    using System.Threading.Tasks;
    public class HttpClientWrapper : IDisposable, IHttpClientWrapper
    {
        private readonly HttpClient httpClient;

        public HttpClientWrapper()
        {
            this.httpClient = new HttpClient();
        }

        public HttpClientWrapper(HttpClient httpClient)
        {
            //Assert.ArgumentNotNull(httpClient, nameof(httpClient));
            this.httpClient = httpClient;
        }

        public TimeSpan TimeOut
        {
            get { return this.httpClient.Timeout; }
        }

        public Task<HttpResponseMessage> SendAsync(HttpRequestMessage request)
        {
            return this.httpClient.SendAsync(request);
        }

        public Task<HttpResponseMessage> PostAsync(Uri uri, HttpContent content)
        {
            return this.httpClient.PostAsync(uri, content);
        }

        public void Dispose()
        {
            this.Dispose(true);
            GC.SuppressFinalize(this);
        }

        protected virtual void Dispose(bool disposing)
        {
            this.httpClient?.Dispose();
        }
    }
}
