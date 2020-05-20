using System.Collections.Generic;
using MarketoApiLibrary.Asset.SmartLists.Request;
using MarketoApiLibrary.Common.Model;

namespace MarketoApiLibrary.Asset.SmartLists
{
    public class SmartListsRequestFactory : ISmartListsRequestFactory
    {
        public GetSmartListsRequest CreateGetSmartListRequest()
        {
            var request = new GetSmartListsRequest();
            request.Offset = 0;
            request.MaxReturn = 20;
           // request.Folder = new Dictionary<string, dynamic> { { "id", 77128 }, { "type", "Folder" } };

            return request;
        }

        public GetSmartListByIdRequest CreateGetSmartListByIdRequest()
        {
            var request = new GetSmartListByIdRequest();
            return request;
        }
    }
}
