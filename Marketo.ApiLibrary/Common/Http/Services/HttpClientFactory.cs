using System;
using System.Collections.Concurrent;
using System.Linq;
using System.Net.Http;

namespace Marketo.ApiLibrary.Common.Http.Services
{
    public class HttpClientFactory : IHttpClientFactory, IDisposable
    {
        private readonly ConcurrentDictionary<string, IHttpClientWrapper> _clients;
        private readonly ConcurrentBag<string> _registeredEndpoints;
        private readonly int _defaultHttpClientTimeout;

        private bool _disposed = false;

        public HttpClientFactory()
        {
            this._clients = new ConcurrentDictionary<string, IHttpClientWrapper>();
            this._registeredEndpoints = new ConcurrentBag<string>();
            this._defaultHttpClientTimeout = 1000;
        }

        public IHttpClientWrapper GetHttpClient(Uri uri, string key = "default")
        {
            this.RegisterEndpoint(uri);

            var timeout = TimeSpan.FromSeconds(this._defaultHttpClientTimeout);
            var httpClient = new HttpClient { Timeout = timeout };

            var wrapper = new HttpClientWrapper(httpClient);
            return this._clients.GetOrAdd(key + timeout, wrapper);
        }

        public IHttpClientWrapper GetHttpClient(Uri uri, int timeout, string key = "default")
        {
            this.RegisterEndpoint(uri);

            var timespan = TimeSpan.FromSeconds(timeout);
            var httpClient = new HttpClient { Timeout = timespan };

            var wrapper = new HttpClientWrapper(httpClient);
            return this._clients.GetOrAdd(key + timeout, wrapper);
        }


        private void RegisterEndpoint(Uri uri)
        {
            var key = uri.GetComponents(UriComponents.SchemeAndServer, UriFormat.SafeUnescaped);
            if (this._registeredEndpoints.Contains(key))
                return;

            var dnsRefreshTimeout = ServicePointManagerUtility.DnsRefreshTimeout;
            var endpoint = ServicePointManagerUtility.FindServicePoint(uri);

            if (endpoint.ConnectionLeaseTimeout < dnsRefreshTimeout)
                endpoint.ConnectionLeaseTimeout = dnsRefreshTimeout;

            this._registeredEndpoints.Add(key);
        }

        public void Dispose()
        {
            this.Dispose(true);
            GC.SuppressFinalize(this);
        }

        protected virtual void Dispose(bool disposing)
        {
            if (this._disposed)
                return;

            if (disposing)
            {
                foreach (var httpClient in this._clients.Values)
                    httpClient.Dispose();
            }

            this._disposed = true;
        }
        /// <summary>
        /// destructor
        /// </summary>
        ~HttpClientFactory()
        {
            this.Dispose(false);
        }
    }
}
