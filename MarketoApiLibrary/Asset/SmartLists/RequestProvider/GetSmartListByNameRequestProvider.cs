﻿using MarketoApiLibrary.Asset.SmartLists.Request;
using MarketoApiLibrary.Common.Configuration;
using MarketoApiLibrary.Common.Http.Oauth;
using MarketoApiLibrary.Common.Http.Services;
using System.Collections.Generic;
using System.Net.Http;

namespace MarketoApiLibrary.Asset.SmartLists.RequestProvider
{
    public class GetSmartListByNameRequestProvider : BaseHttpRequestProvider<GetSmartListByNameRequest>
    {
        public GetSmartListByNameRequestProvider(
            IConfigurationProvider configuration,
            IAuthenticationTokenProvider authenticationTokenProvider) :
            base(configuration, authenticationTokenProvider)
        {
        }

        protected override string GetRelativeUrl(GetSmartListByNameRequest request)
        {
            return $"/{Constants.UrlSegments.Asset}/{Constants.UrlSegments.Version}/{Constants.UrlSegments.SmartList}/{Constants.UrlSegments.ByName}";
        }
        protected override HttpMethod GetHttpMethod()
        {
            return HttpMethod.Get;
        }

        protected override Dictionary<string, string> GetQueryString(GetSmartListByNameRequest request)
        {
            var qs = new Dictionary<string, string>
            {
                { Constants.QueryParameters.Asset.SmartList.Keys.SmartListName, request.Name},
            };

            return qs;
        }
    }
}
