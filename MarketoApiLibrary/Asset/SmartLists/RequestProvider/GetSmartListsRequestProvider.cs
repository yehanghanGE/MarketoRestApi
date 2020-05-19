using System.Collections.Generic;
using System.Net.Http;
using MarketoApiLibrary.Asset.SmartLists.Request;
using MarketoApiLibrary.Common.Configuration;
using MarketoApiLibrary.Common.Http.Oauth;
using MarketoApiLibrary.Common.Http.Services;
using Newtonsoft.Json;

namespace MarketoApiLibrary.Asset.SmartLists.RequestProvider
{
    class GetSmartListsRequestProvider : BaseHttpRequestProvider<GetSmartListsRequest>
    {
        public GetSmartListsRequestProvider(IConfigurationProvider configuration, IAuthenticationTokenProvider authenticationTokenProvider) : base(configuration, authenticationTokenProvider)
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
            return new Dictionary<string, string>
            {
                { Constants.QueryParameters.Asset.SmartList.Keys.Folder, JsonConvert.SerializeObject(request.Folder)},
                { Constants.QueryParameters.Asset.SmartList.Keys.Offset, request.Offset.ToString()},
                { Constants.QueryParameters.Asset.SmartList.Keys.MaxReturn, request.MaxReturn.ToString()},
                { Constants.QueryParameters.Asset.SmartList.Keys.EarliestUpdatedAt, request.EarliestUpdatedAt},
                { Constants.QueryParameters.Asset.SmartList.Keys.LatestUpdatedAt, request.LatestUpdatedAt}
            };
        }
    }
}
