using Marketo.ApiLibrary.Asset.Folders.Request;
using Marketo.ApiLibrary.Common.Configuration;
using Marketo.ApiLibrary.Common.Http.Oauth;
using Marketo.ApiLibrary.Common.Http.Services;
using System.Collections.Generic;
using System.Net.Http;

namespace Marketo.ApiLibrary.Asset.Folders.RequestProvider
{
    public class DeleteFolderRequestProvider : BaseHttpRequestProvider<DeleteFolderRequest>
    {
        public DeleteFolderRequestProvider(IConfigurationProvider configuration,
            IAuthenticationTokenProvider authenticationTokenProvider) :
            base(configuration, authenticationTokenProvider)
        {
        }

        protected override string GetRelativeUrl(DeleteFolderRequest request)
        {
            return $"/{Constants.UrlSegments.Asset}/{Constants.UrlSegments.Version}/{Constants.UrlSegments.Folder}/{request.FolderId}/{Constants.UrlSegments.Delete}";
        }

        protected override HttpMethod GetHttpMethod()
        {
            return HttpMethod.Post;
        }

        protected override Dictionary<string, string> GetQueryString(DeleteFolderRequest request)
        {
            var qs = new Dictionary<string, string>
            {
                { Constants.QueryParameters.Asset.Folder.Keys.Type, request.FolderType}
            };

            return qs;
        }
    }
}
