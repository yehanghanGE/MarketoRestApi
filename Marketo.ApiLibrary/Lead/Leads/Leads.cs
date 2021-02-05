using Marketo.ApiLibrary.Common.DI;
using Marketo.ApiLibrary.Lead.Leads.Response;

namespace Marketo.ApiLibrary.Lead.Leads
{
    public class Leads
    {
        private static ILeadsController _leadsController;

        public static ILeadsController LeadsController
        {
            get
            {
                if (_leadsController == null)
                {
                    Initialize();
                }

                return _leadsController;
            }
        }

        static Leads()
        {
            Initialize();
        }

        private static void Initialize()
        {
            _leadsController = MarketoApiContainer.Resolve<ILeadsController>();
        }



        public static LeadAttributeResponse DescibeLead()
        {

        }
    }
}
