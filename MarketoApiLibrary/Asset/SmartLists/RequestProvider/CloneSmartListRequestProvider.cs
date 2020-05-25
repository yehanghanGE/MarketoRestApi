using MarketoApiLibrary.Asset.SmartLists.Request;
using MarketoApiLibrary.Common.Configuration;
using MarketoApiLibrary.Common.Http.Oauth;
using MarketoApiLibrary.Common.Http.Services;
using Newtonsoft.Json;
using System.Net.Http;
using System.Text;

namespace MarketoApiLibrary.Asset.SmartLists.RequestProvider
{
    public class CloneSmartListRequestProvider : BaseHttpRequestProvider<CloneSmartListRequest>
    {
        public CloneSmartListRequestProvider(
            IConfigurationProvider configuration,
            IAuthenticationTokenProvider authenticationTokenProvider) :
            base(configuration, authenticationTokenProvider)
        {

        }

        protected override string GetRelativeUrl(CloneSmartListRequest request)
        {
            return $"/{Constants.UrlSegments.Asset}/{Constants.UrlSegments.Version}/{Constants.UrlSegments.SmartList}/{request.Id}/{Constants.UrlSegments.Clone}";
        }

        protected override HttpMethod GetHttpMethod()
        {
            return HttpMethod.Post;
        }

        protected override HttpContent GetBody(CloneSmartListRequest request)
        {
            var sb = new StringBuilder();
            sb.Append("&name=" + request.Name);
            sb.Append("&folder=" + JsonConvert.SerializeObject(request.Folder));
            if (request.Description != null)
            {
                sb.Append("&description=" + request.Description);
            }

            return new StringContent(sb.ToString(), Encoding.UTF8, "application/json");
        }
    }
}
