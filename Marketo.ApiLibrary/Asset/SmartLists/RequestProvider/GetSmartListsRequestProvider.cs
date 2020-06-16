using Marketo.ApiLibrary.Asset.SmartLists.Request;
using Marketo.ApiLibrary.Common.Configuration;
using Marketo.ApiLibrary.Common.Http.Oauth;
using Marketo.ApiLibrary.Common.Http.Services;
using Newtonsoft.Json;
using System.Collections.Generic;
using System.Net.Http;

namespace Marketo.ApiLibrary.Asset.SmartLists.RequestProvider
{
    public class GetSmartListsRequestProvider : BaseHttpRequestProvider<GetSmartListsRequest>
    {
        public GetSmartListsRequestProvider(IConfigurationProvider configuration,
            IAuthenticationTokenProvider authenticationTokenProvider) :
            base(configuration, authenticationTokenProvider)
        {

        }

        protected override string GetRelativeUrl(GetSmartListsRequest request)
        {
            return $"/{Constants.UrlSegments.Asset}/{Constants.UrlSegments.Version}/{Constants.UrlSegments.SmartLists}";
        }

        protected override HttpMethod GetHttpMethod()
        {
            return HttpMethod.Get;
        }

        protected override Dictionary<string, string> GetQueryString(GetSmartListsRequest request)
        {
            var qs = new Dictionary<string, string>
            {
                { Constants.QueryParameters.Asset.SmartList.Keys.Offset, request.Offset.ToString()},
                { Constants.QueryParameters.Asset.SmartList.Keys.MaxReturn, request.MaxReturn.ToString()},
                { Constants.QueryParameters.Asset.SmartList.Keys.EarliestUpdatedAt, request.EarliestUpdatedAt},
                { Constants.QueryParameters.Asset.SmartList.Keys.LatestUpdatedAt, request.LatestUpdatedAt}
            };

            if (request.Folder.Count > 0)
            {
                qs.Add(Constants.QueryParameters.Asset.SmartList.Keys.Folder, JsonConvert.SerializeObject(request.Folder));
            }

            return qs;
        }
    }
}
