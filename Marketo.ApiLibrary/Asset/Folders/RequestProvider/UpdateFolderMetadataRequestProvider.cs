using Marketo.ApiLibrary.Asset.Folders.Request;
using Marketo.ApiLibrary.Common.Configuration;
using Marketo.ApiLibrary.Common.Http.Oauth;
using Marketo.ApiLibrary.Common.Http.Services;
using System.Collections.Generic;
using System.Net.Http;

namespace Marketo.ApiLibrary.Asset.Folders.RequestProvider
{
    public class UpdateFolderMetadataRequestProvider : BaseHttpRequestProvider<UpdateFolderMetadataRequest>
    {
        public UpdateFolderMetadataRequestProvider(IConfigurationProvider configuration,
            IAuthenticationTokenProvider authenticationTokenProvider) :
            base(configuration, authenticationTokenProvider)
        {
        }


        protected override string GetRelativeUrl(UpdateFolderMetadataRequest request)
        {
            return $"/{Constants.UrlSegments.Asset}/{Constants.UrlSegments.Version}/{Constants.UrlSegments.Folder}/{request.FolderId}.json";
        }

        protected override HttpMethod GetHttpMethod()
        {
            return HttpMethod.Post;
        }

        protected override Dictionary<string, string> GetQueryString(UpdateFolderMetadataRequest request)
        {
            var qs = new Dictionary<string, string>
            {
                { Constants.QueryParameters.Asset.Folder.Keys.Type, request.FolderType},
                { Constants.QueryParameters.Asset.Folder.Keys.IsArchive, request.IsArchive.ToString()}
            };

            if (!string.IsNullOrEmpty(request.Description))
            {
                qs.Add(Constants.QueryParameters.Asset.Folder.Keys.Description, request.Description);
            }

            if (!string.IsNullOrEmpty(request.FolderName))
            {
                qs.Add(Constants.QueryParameters.Asset.Folder.Keys.Name, request.FolderName);
            }


            return qs;
        }
    }
}
