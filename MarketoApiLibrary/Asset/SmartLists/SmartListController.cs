using MarketoApiLibrary.Asset.SmartLists.Request;
using MarketoApiLibrary.Asset.SmartLists.RequestProcessor;
using MarketoApiLibrary.Asset.SmartLists.Response;
using MarketoApiLibrary.Common.Model;

namespace MarketoApiLibrary.Asset.SmartLists
{
    public class SmartListController : ISmartListController
    {
        private readonly GetSmartListsProcessor _getSmartListsProcessor;
        private readonly GetSmartListByIdProcessor _getSmartListByIdProcessor;
        private readonly GetSmartListByNameProcessor _getSmartListByNameProcessor;
        private readonly DeleteSmartListProcessor _deleteSmartListProcessor;
        private readonly CloneSmartListProcessor _cloneSmartListProcessor;

        public SmartListController(GetSmartListsProcessor getSmartListsProcessor,
            GetSmartListByIdProcessor getSmartListByIdProcessor,
            GetSmartListByNameProcessor getSmartListByNameProcessor, 
            DeleteSmartListProcessor deleteSmartListProcessor, 
            CloneSmartListProcessor cloneSmartListProcessor)
        {
            _getSmartListsProcessor = getSmartListsProcessor;
            _getSmartListByIdProcessor = getSmartListByIdProcessor;
            _getSmartListByNameProcessor = getSmartListByNameProcessor;
            _deleteSmartListProcessor = deleteSmartListProcessor;
            _cloneSmartListProcessor = cloneSmartListProcessor;
        }

        public SmartListsResponse GetSmartLists()
        {
            var request = new GetSmartListsRequest { Offset = 0, MaxReturn = 20 };
            var result = _getSmartListsProcessor.Process(request);
            return result;
        }

        public SmartListsResponseWithRules GetSmartListById(long id, bool includeRules)
        {
            var request = new GetSmartListByIdRequest
            {
                Id = id,
                IncludeRules = includeRules
            };
            var result = _getSmartListByIdProcessor.Process(request);

            return result;
        }

        public SmartListsResponse GetSmartListByName(string name)
        {
            var request = new GetSmartListByNameRequest
            {
                Name = name
            };
            var result = _getSmartListByNameProcessor.Process(request);

            return result;
        }

        public SmartListDeleteResponse DeleteSmartList(long id)
        {
            var request = new DeleteSmartListRequest {Id = id};

            var result = _deleteSmartListProcessor.Process(request);
                                                
            return result;
        }

        public SmartListsResponse CloneSmartList(int id, string clonedSmartListName, int parentFolderId, string parentFolderType,
            string description)
        {
            var request = new CloneSmartListRequest
            {
                Id = id,
                Name = clonedSmartListName,
                Description = description,
                Folder = new Folder {Id = parentFolderId, Type = parentFolderType}
            };

            var result = _cloneSmartListProcessor.Process(request);

            return result;
        }
    }
}
