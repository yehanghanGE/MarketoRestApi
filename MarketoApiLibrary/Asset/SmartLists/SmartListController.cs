using System.Threading.Tasks;
using MarketoApiLibrary.Asset.SmartLists.Request;
using MarketoApiLibrary.Asset.SmartLists.RequestProcessor;
using MarketoApiLibrary.Asset.SmartLists.Response;

namespace MarketoApiLibrary.Asset.SmartLists
{
    public class SmartListController : ISmartListController
    {
        private readonly GetSmartListsProcessor _processor;

        public SmartListController(GetSmartListsProcessor processor)
        {
            _processor = processor;
        }

        public SmartListsResponse GetSmartLists()
        {
            var request = new GetSmartListsRequest {Offset = 0, MaxReturn = 20};

            var result = _processor.Process(request);
            return result;
        }
    }
}
