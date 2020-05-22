using MarketoApiLibrary.Asset.SmartLists.Request;
using MarketoApiLibrary.Asset.SmartLists.RequestProcessor;
using MarketoApiLibrary.Asset.SmartLists.Response;

namespace MarketoApiLibrary.Asset.SmartLists
{
    public class SmartListController : ISmartListController
    {
        private readonly GetSmartListsProcessor _getSmartListsProcessor;
        private readonly GetSmartListByIdProcessor _getSmartListByIdProcessor;

        public SmartListController(GetSmartListsProcessor getSmartListsProcessor, GetSmartListByIdProcessor getSmartListByIdProcessor)
        {
            _getSmartListsProcessor = getSmartListsProcessor;
            _getSmartListByIdProcessor = getSmartListByIdProcessor;
        }

        public SmartListsResponse GetSmartLists()
        {
            var request = new GetSmartListsRequest {Offset = 0, MaxReturn = 20};

            var result = _getSmartListsProcessor.Process(request);
            return result;
        }

        public SmartListsResponseWithRules GetSmartListById(long id, bool includeRules)
        {
            var request = new GetSmartListByIdRequest();
            request.Id = id;
            request.IncludeRules = includeRules;
            var result = _getSmartListByIdProcessor.Process(request);

            return result;
        }

        public SmartListsResponse GetSmartListByName(string name)
        {
            throw new System.NotImplementedException();
        }
    }
}
