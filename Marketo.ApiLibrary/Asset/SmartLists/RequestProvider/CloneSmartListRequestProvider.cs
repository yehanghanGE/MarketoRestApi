using System.Collections.Generic;
using Marketo.ApiLibrary.Asset.SmartLists.Request;
using Marketo.ApiLibrary.Common.Configuration;
using Marketo.ApiLibrary.Common.Http.Oauth;
using Marketo.ApiLibrary.Common.Http.Services;
using Newtonsoft.Json;
using System.Net.Http;
using System.Text;

namespace Marketo.ApiLibrary.Asset.SmartLists.RequestProvider
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

            var dict = new Dictionary<string, string>
            {
                {Constants.QueryParameters.Asset.SmartList.Keys.SmartListName, request.Name},
                {Constants.QueryParameters.Asset.SmartList.Keys.Description, request.Description},
                {Constants.QueryParameters.Asset.SmartList.Keys.Folder, JsonConvert.SerializeObject(request.Folder)}
            };

            return new FormUrlEncodedContent(dict);
        }
    }
}
