using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Web;

namespace MarketoApiLibrary.Common.Http.Helper
{
    public class UriBuilder
    {
        private readonly string url;
        private readonly Dictionary<string, string> queryParams;

        /// <summary>
        /// Initialize a new UriBuilder instance on basis of a URL
        /// </summary>
        /// <param name="baseUrl">Base URL (e.g. https://gelifesciences.com/en/us) </param>
        /// <param name="additionalSegments">Additional path segments (e.g. /en/us, /shop/cell-therapy, /en/se/support)</param>
        /// <returns></returns>
        public static UriBuilder Init(string baseUrl, params string[] additionalSegments)
        {
            string finalUrl;
            if (additionalSegments.Any())
            {
                var additionalSegment = string.Join("/", additionalSegments.Select(s => s.Trim('/')));
                finalUrl = $"{baseUrl.TrimEnd('/')}/{additionalSegment}";
            }
            else
            {
                finalUrl = baseUrl.TrimEnd('/');
            }

            return new UriBuilder(finalUrl);
        }

        private UriBuilder(string url)
        {
            //Assert.ArgumentNotNullOrEmpty(url, nameof(url));

            this.queryParams = new Dictionary<string, string>();
            if (!url.Contains("?"))
            {
                this.url = url;
                return;
            }

            var split = url.Split('?');
            this.url = split[0];

            var values = HttpUtility.ParseQueryString(split[1]);
            foreach (var key in values.AllKeys)
            {
                this.queryParams[key] = values[key];
            }
        }

        public UriBuilder QueryParam<TValue>(string key, TValue value)
        {
            //Assert.ArgumentNotNullOrEmpty(key, nameof(key));

            if (value == null)
                this.queryParams.Remove(key);
            else
                this.queryParams[key] = value.ToString();

            return this;
        }

        public Uri Build()
        {
            var query = this.BuildQueryString();
            var uri = !string.IsNullOrEmpty(query) ? $"{this.url}?{query}" : this.url;
            return new Uri(uri, UriKind.RelativeOrAbsolute);
        }

        private string BuildQueryString()
        {
            var query = new StringBuilder();
            foreach (var parameter in this.queryParams)
            {
                if (query.Length > 0)
                    query.Append("&");

                var input = HttpUtility.UrlEncode(parameter.Value);
                query.Append($"{parameter.Key}={input}");
            }
            return query.ToString();
        }
    }
}
