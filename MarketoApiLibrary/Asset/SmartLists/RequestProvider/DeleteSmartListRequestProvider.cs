using System.Net.Http;
using MarketoApiLibrary.Asset.SmartLists.Request;
using MarketoApiLibrary.Common.Configuration;
using MarketoApiLibrary.Common.Http.Oauth;
using MarketoApiLibrary.Common.Http.Services;

namespace MarketoApiLibrary.Asset.SmartLists.RequestProvider
{
    public class DeleteSmartListRequestProvider : BaseHttpRequestProvider<DeleteSmartListRequest>
    {
        public DeleteSmartListRequestProvider(
            IConfigurationProvider configuration,
            IAuthenticationTokenProvider authenticationTokenProvider) :
            base(configuration, authenticationTokenProvider)
        {

        }
        protected override string GetRelativeUrl(DeleteSmartListRequest request)
        {
            return $"/{Constants.UrlSegments.Asset}/{Constants.UrlSegments.Version}/{Constants.UrlSegments.SmartList}/{request.Id}/{Constants.UrlSegments.Delete}";
        }

        protected override HttpMethod GetHttpMethod()
        {
            return HttpMethod.Post;
        }
    }
}
