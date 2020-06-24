using Marketo.ApiLibrary.Common.Configuration;
using Marketo.ApiLibrary.Common.Http.Oauth;
using Marketo.ApiLibrary.Common.Http.Services;
using Marketo.ApiLibrary.Leads.BulkExportLeads.Request;
using System.Net.Http;

namespace Marketo.ApiLibrary.Leads.BulkExportLeads.RequestProvider
{
    public class CreateExportLeadJobRequestProvider : BaseHttpRequestProvider<CreateExportLeadJobRequest>
    {
        public CreateExportLeadJobRequestProvider(IConfigurationProvider configuration,
            IAuthenticationTokenProvider authenticationTokenProvider) :
            base(configuration, authenticationTokenProvider)
        {
        }

        protected override string GetRelativeUrl(CreateExportLeadJobRequest request)
        {
            return $"/{Constants.UrlSegments.Bulk}/{Constants.UrlSegments.Version}/{Constants.UrlSegments.Leads}/{Constants.UrlSegments.Export}/{Constants.UrlSegments.Create}";
        }

        protected override HttpMethod GetHttpMethod()
        {
            return HttpMethod.Post;
        }

        protected override HttpContent GetBody(CreateExportLeadJobRequest request)
        {
            return new HttpContent();
        }

    }
}
