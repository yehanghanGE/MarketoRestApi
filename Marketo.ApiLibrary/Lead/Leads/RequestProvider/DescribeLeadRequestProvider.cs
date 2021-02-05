using Marketo.ApiLibrary.Common.Configuration;
using Marketo.ApiLibrary.Common.Http.Oauth;
using Marketo.ApiLibrary.Common.Http.Services;
using Marketo.ApiLibrary.Lead.Leads.Request;
using System.Net.Http;

namespace Marketo.ApiLibrary.Lead.Leads.RequestProvider
{
    public class DescribeLeadRequestProvider : BaseHttpRequestProvider<DescribeLeadRequest>
    {
        public DescribeLeadRequestProvider(IConfigurationProvider configuration,
            IAuthenticationTokenProvider authenticationTokenProvider)
            : base(configuration, authenticationTokenProvider)
        {
        }

        protected override string GetRelativeUrl(DescribeLeadRequest request)
        {
            throw new System.NotImplementedException();
        }

        protected override HttpMethod GetHttpMethod()
        {
            return HttpMethod.Get;
        }
    }
}
