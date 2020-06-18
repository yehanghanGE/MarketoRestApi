using Marketo.ApiLibrary.Common.DI;

namespace Marketo.ApiLibrary.Leads.BulkExportLeads
{
    public class BulkExportLeads
    {
        private static IBulkExportLeadsController _bulkExportLeadsController;

        public static IBulkExportLeadsController BulkExportLeadsController
        {
            get
            {
                if (_bulkExportLeadsController == null)
                {
                    Initialize();
                }

                return _bulkExportLeadsController;
            }
        }

        static BulkExportLeads()
        {
            Initialize();
        }

        private static void Initialize()
        {
            _bulkExportLeadsController = MarketoApiContainer.Resolve<IBulkExportLeadsController>();
        }
        public static void CreateExportLeadJob()
        {

        }
    }
}
