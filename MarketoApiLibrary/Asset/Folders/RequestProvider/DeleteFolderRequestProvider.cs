using MarketoApiLibrary.Asset.Folders.Request;
using MarketoApiLibrary.Common.Configuration;
using MarketoApiLibrary.Common.Http.Oauth;
using MarketoApiLibrary.Common.Http.Services;
using System.Collections.Generic;
using System.Net.Http;

namespace MarketoApiLibrary.Asset.Folders.RequestProvider
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
