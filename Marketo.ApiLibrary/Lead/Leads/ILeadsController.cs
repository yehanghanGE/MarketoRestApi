using Marketo.ApiLibrary.Lead.Leads.Response;

namespace Marketo.ApiLibrary.Lead.Leads
{
    public interface ILeadsController
    {
        LeadAttributeResponse DescribeLead();
    }
}
