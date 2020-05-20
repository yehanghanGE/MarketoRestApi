using System.Collections.Generic;
using System.Net.Http;
using MarketoApiLibrary.Asset.SmartLists.Request;
using MarketoApiLibrary.Common.Configuration;
using MarketoApiLibrary.Common.Http.Oauth;
using MarketoApiLibrary.Common.Http.Services;
using Newtonsoft.Json;

namespace MarketoApiLibrary.Asset.SmartLists.RequestProvider
{
    class GetSmartListByIdRequestProvider : BaseHttpRequestProvider<GetSmartListByIdRequest>
    {
        public GetSmartListByIdRequestProvider(IConfigurationProvider configuration, IAuthenticationTokenProvider authenticationTokenProvider) : base(configuration, authenticationTokenProvider)
        {

        }

        protected override string GetRelativeUrl(GetSmartListByIdRequest request)
        {
            return $"/{Constants.UrlSegments.Asset}/{Constants.UrlSegments.Version}/{Constants.UrlSegments.SmartList}/{request.Id}.json";
        }

        protected override HttpMethod GetHttpMethod()
        {
            return HttpMethod.Get;
        }

        protected override Dictionary<string, string> GetQueryString(GetSmartListByIdRequest request)
        {
            var qs = new Dictionary<string, string>
            {
                { Constants.QueryParameters.Asset.SmartList.Keys.IncludeRules, request.IncludeRules.ToString()},
            };

            return qs;
        }
    }
}
