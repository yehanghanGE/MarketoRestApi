using MarketoApiLibrary.Asset.SmartLists.Request;

namespace MarketoApiLibrary.Asset.SmartLists
{
    public interface ISmartListsRequestFactory
    {
        GetSmartListsRequest CreateGetSmartListRequest();
    }
}