using System.Threading.Tasks;

namespace Marketo.ApiLibrary
{
    public interface IMarketoClient
    {

        void BulkExportActivities();
        void BulkExportLeads();
    }
}