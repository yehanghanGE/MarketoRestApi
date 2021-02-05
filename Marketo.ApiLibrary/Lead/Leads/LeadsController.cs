using Marketo.ApiLibrary.Lead.Leads.Request;
using Marketo.ApiLibrary.Lead.Leads.Response;

namespace Marketo.ApiLibrary.Lead.Leads
{
    public class LeadsController : ILeadsController
    {
        public LeadAttributeResponse DescribeLead()
        {
            var request = new DescribeLeadRequest();
            var result = new LeadAttributeResponse();
            return result;
        }
    }
}
