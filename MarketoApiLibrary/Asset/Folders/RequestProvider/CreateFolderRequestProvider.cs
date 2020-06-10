using MarketoApiLibrary.Asset.Folders.Request;
using MarketoApiLibrary.Common.Configuration;
using MarketoApiLibrary.Common.Http.Oauth;
using MarketoApiLibrary.Common.Http.Services;
using Newtonsoft.Json;
using System.Collections.Generic;
using System.Net.Http;

namespace MarketoApiLibrary.Asset.Folders.RequestProvider
{
    public class CreateFolderRequestProvider : BaseHttpRequestProvider<CreateFolderRequest>
    {
        public CreateFolderRequestProvider(IConfigurationProvider configuration,
            IAuthenticationTokenProvider authenticationTokenProvider) :
            base(configuration, authenticationTokenProvider)
        {
        }

        protected override string GetRelativeUrl(CreateFolderRequest request)
        {
            return $"/{Constants.UrlSegments.Asset}/{Constants.UrlSegments.Version}/{Constants.UrlSegments.Folders}";
        }

        protected override HttpMethod GetHttpMethod()
        {
            return HttpMethod.Post;
        }

        protected override Dictionary<string, string> GetQueryString(CreateFolderRequest request)
        {
            var qs = new Dictionary<string, string>
            {
                { Constants.QueryParameters.Asset.Folder.Keys.Name, request.FolderName},
                { Constants.QueryParameters.Asset.Folder.Keys.Description, request.Description},
                { Constants.QueryParameters.Asset.Folder.Keys.Parent, JsonConvert.SerializeObject(request.Parent)},
            };

            return qs;
        }
    }
}
