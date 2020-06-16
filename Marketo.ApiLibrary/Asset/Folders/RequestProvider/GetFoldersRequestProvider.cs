using Marketo.ApiLibrary.Asset.Folders.Request;
using Marketo.ApiLibrary.Common.Configuration;
using Marketo.ApiLibrary.Common.Http.Oauth;
using Marketo.ApiLibrary.Common.Http.Services;
using Newtonsoft.Json;
using System.Collections.Generic;
using System.Net.Http;

namespace Marketo.ApiLibrary.Asset.Folders.RequestProvider
{
    public class GetFoldersRequestProvider : BaseHttpRequestProvider<GetFoldersRequest>
    {
        public GetFoldersRequestProvider(IConfigurationProvider configuration,
            IAuthenticationTokenProvider authenticationTokenProvider) :
            base(configuration, authenticationTokenProvider)
        {
        }

        protected override string GetRelativeUrl(GetFoldersRequest request)
        {
            return $"/{Constants.UrlSegments.Asset}/{Constants.UrlSegments.Version}/{Constants.UrlSegments.Folders}";
        }

        protected override HttpMethod GetHttpMethod()
        {
            return HttpMethod.Get;
        }

        protected override Dictionary<string, string> GetQueryString(GetFoldersRequest request)
        {
            var qs = new Dictionary<string, string>
            {
                { Constants.QueryParameters.Asset.SmartList.Keys.Root, JsonConvert.SerializeObject(request.Root)}
            };

            if (request.MaxDepth > 0)
            {
                qs.Add(Constants.QueryParameters.Asset.SmartList.Keys.MaxReturn, request.MaxReturn.ToString());
            }
            if (request.Offset > 0)
            {
                qs.Add(Constants.QueryParameters.Asset.SmartList.Keys.Offset, request.Offset.ToString());
            }
            if (request.MaxReturn > 0)
            {
                qs.Add(Constants.QueryParameters.Asset.SmartList.Keys.MaxReturn, request.MaxReturn.ToString());
            }
            if (request.WorkSpace != null)
            {
                qs.Add(Constants.QueryParameters.Asset.SmartList.Keys.WorkSpace, request.WorkSpace);
            }

            return qs;
        }
    }
}
