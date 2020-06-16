using Marketo.ApiLibrary.Asset.Folders.Request;
using Marketo.ApiLibrary.Common.Configuration;
using Marketo.ApiLibrary.Common.Http.Oauth;
using Marketo.ApiLibrary.Common.Http.Services;
using System.Collections.Generic;
using System.Net.Http;

namespace Marketo.ApiLibrary.Asset.Folders.RequestProvider
{
    public class GetFolderContentsRequestProvider : BaseHttpRequestProvider<GetFolderContentsRequest>
    {
        public GetFolderContentsRequestProvider(IConfigurationProvider configuration,
            IAuthenticationTokenProvider authenticationTokenProvider) :
            base(configuration, authenticationTokenProvider)
        {
        }

        protected override string GetRelativeUrl(GetFolderContentsRequest request)
        {
            return $"/{Constants.UrlSegments.Asset}/{Constants.UrlSegments.Version}/{Constants.UrlSegments.Folder}/{request.FolderId}/{Constants.UrlSegments.Content}";
        }

        protected override HttpMethod GetHttpMethod()
        {
            return HttpMethod.Get;
        }

        protected override Dictionary<string, string> GetQueryString(GetFolderContentsRequest request)
        {
            var qs = new Dictionary<string, string>
            {
                { Constants.QueryParameters.Asset.Folder.Keys.Type, request.FolderType},
                { Constants.QueryParameters.Asset.Folder.Keys.MaxReturn, request.MaxReturn.ToString()},
                { Constants.QueryParameters.Asset.Folder.Keys.Offset, request.Offset.ToString()},
            };

            return qs;
        }
    }
}
