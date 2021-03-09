using Marketo.ApiLibrary.Lead.Leads.Request;
using Marketo.ApiLibrary.Lead.Leads.RequestProcessor;
using Marketo.ApiLibrary.Lead.Leads.Response;

namespace Marketo.ApiLibrary.Lead.Leads
{
    public class LeadsController : ILeadsController
    {
        private readonly DescribeLeadProcessor _describeLeadProcessor;


        public LeadsController(DescribeLeadProcessor describeLeadProcessor)
        {
            _describeLeadProcessor = describeLeadProcessor;
        }
        public LeadAttributeResponse DescribeLead()
        {
            var request = new DescribeLeadRequest();
            var result = _describeLeadProcessor.Process(request);
            return result;
        }
    }
}
