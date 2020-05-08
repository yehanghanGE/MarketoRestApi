using MarketoApiLibrary.Asset.SmartLists.Request;
using MarketoApiLibrary.Request;

namespace MarketoApiLibrary.Asset.SmartLists
{
    public class SmartListsRequestFactory : ISmartListsRequestFactory
    {
        public GetSmartListsRequest CreateGetSmartListRequest()
        {
            var request = new GetSmartListsRequest();
            return request;
        }

        public GetSmartListByIdRequest CreateGetSmartListByIdRequest()
        {
            var request = new GetSmartListByIdRequest();
            return request;
        }
    }
}
