using Marketo.ApiLibrary.Common.DI;
using Marketo.ApiLibrary.Leads.BulkExportLeads.Response;

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
        /// <summary>
        /// POST /bulk/v1/leads/export/create.json
        /// </summary>
        /// <returns></returns>
        public static CreateExportLeadJobResponse CreateExportLeadJob()
        {
            return BulkExportLeadsController.CreateExportLeadJob();
        }
    }
}
