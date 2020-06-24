using Marketo.ApiLibrary.Leads.BulkExportLeads.Response;

namespace Marketo.ApiLibrary.Leads.BulkExportLeads
{
    public interface IBulkExportLeadsController
    {
        CreateExportLeadJobResponse CreateExportLeadJob();
    }
}
