using Marketo.ApiLibrary.Asset.Folders.Request;
using Marketo.ApiLibrary.Common.Configuration;
using Marketo.ApiLibrary.Common.Http.Oauth;
using Marketo.ApiLibrary.Common.Http.Services;
using Newtonsoft.Json;
using System.Collections.Generic;
using System.Net.Http;

namespace Marketo.ApiLibrary.Asset.Folders.RequestProvider
{
    public class GetFolderByNameRequestProvider : BaseHttpRequestProvider<GetFolderByNameRequest>
    {
        public GetFolderByNameRequestProvider(IConfigurationProvider configuration,
            IAuthenticationTokenProvider authenticationTokenProvider) :
            base(configuration, authenticationTokenProvider)
        {
        }

        protected override string GetRelativeUrl(GetFolderByNameRequest request)
        {
            return $"/{Constants.UrlSegments.Asset}/{Constants.UrlSegments.Version}/{Constants.UrlSegments.Folder}/{Constants.UrlSegments.ByName}";

        }

        protected override HttpMethod GetHttpMethod()
        {
            return HttpMethod.Get;
        }

        protected override Dictionary<string, string> GetQueryString(GetFolderByNameRequest request)
        {
            var qs = new Dictionary<string, string>
            {
                { Constants.QueryParameters.Asset.Folder.Keys.Name, request.Name}
            };

            if (request.Type != null)
            {
                qs.Add(Constants.QueryParameters.Asset.Folder.Keys.Type, request.Type);
            }

            if (request.Root != null)
            {
                qs.Add(Constants.QueryParameters.Asset.Folder.Keys.Root, JsonConvert.SerializeObject(request.Root));
            }

            if (request.WorkSpace != null)
            {
                qs.Add(Constants.QueryParameters.Asset.Folder.Keys.WorkSpace, request.WorkSpace);
            }

            return qs;
        }
    }
}
