using System.Net.Http;
using Marketo.ApiLibrary.Asset.SmartLists.Request;
using Marketo.ApiLibrary.Common.Configuration;
using Marketo.ApiLibrary.Common.Http.Oauth;
using Marketo.ApiLibrary.Common.Http.Services;

namespace Marketo.ApiLibrary.Asset.SmartLists.RequestProvider
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
