using System.Threading.Tasks;

namespace MarketoApiLibrary
{
    public interface IMarketoClient
    {

        void BulkExportActivities();
        void BulkExportLeads();
        Task<string> GetSmartList();
    }
}