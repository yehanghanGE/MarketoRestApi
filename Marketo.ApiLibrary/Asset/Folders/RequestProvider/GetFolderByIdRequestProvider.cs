using Marketo.ApiLibrary.Asset.Folders.Request;
using Marketo.ApiLibrary.Common.Configuration;
using Marketo.ApiLibrary.Common.Http.Oauth;
using Marketo.ApiLibrary.Common.Http.Services;
using System.Collections.Generic;
using System.Net.Http;

namespace Marketo.ApiLibrary.Asset.Folders.RequestProvider
{
    public class GetFolderByIdRequestProvider : BaseHttpRequestProvider<GetFolderByIdRequest>
    {
        public GetFolderByIdRequestProvider(IConfigurationProvider configuration,
            IAuthenticationTokenProvider authenticationTokenProvider) :
            base(configuration, authenticationTokenProvider)
        {
        }

        protected override string GetRelativeUrl(GetFolderByIdRequest request)
        {
            return $"/{Constants.UrlSegments.Asset}/{Constants.UrlSegments.Version}/{Constants.UrlSegments.Folder}/{request.FolderId}.json";
        }

        protected override HttpMethod GetHttpMethod()
        {
            return HttpMethod.Get;
        }


        protected override Dictionary<string, string> GetQueryString(GetFolderByIdRequest request)
        {
            var qs = new Dictionary<string, string>
            {
                { Constants.QueryParameters.Asset.Folder.Keys.Type, request.FolderType}
            };

            return qs;
        }
    }
}
