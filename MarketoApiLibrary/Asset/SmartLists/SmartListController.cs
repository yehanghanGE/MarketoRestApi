using System.Threading.Tasks;
using MarketoApiLibrary.Asset.SmartLists.RequestProcessor;
using MarketoApiLibrary.Asset.SmartLists.Response;

namespace MarketoApiLibrary.Asset.SmartLists
{
    public class SmartListController : ISmartListController
    {
        private readonly ISmartListsRequestFactory _smartListRequestFactory;
        private readonly GetSmartListsProcessor _processor;

        public SmartListController(ISmartListsRequestFactory smartListRequestFactory, GetSmartListsProcessor processor)
        {
            _smartListRequestFactory = smartListRequestFactory;
            _processor = processor;
        }

        public async Task<SmartListResponseWithRules> GetSmartLists<T>()
        {
            var request = _smartListRequestFactory.CreateGetSmartListRequest();
            var result = _processor.Process(request);
            return result;
        }
    }
}
