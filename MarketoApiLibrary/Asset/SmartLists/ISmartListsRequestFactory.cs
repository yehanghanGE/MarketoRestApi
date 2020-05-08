using MarketoApiLibrary.Asset.SmartLists.Request;
using MarketoApiLibrary.Request;

namespace MarketoApiLibrary.Asset.SmartLists
{
    public interface ISmartListsRequestFactory
    {
        GetSmartListsRequest CreateGetSmartListRequest();
    }
}