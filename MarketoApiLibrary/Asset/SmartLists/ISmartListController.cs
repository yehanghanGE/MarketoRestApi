using MarketoApiLibrary.Asset.SmartLists.Response;

namespace MarketoApiLibrary.Asset.SmartLists
{
    public interface ISmartListController
    {
        SmartListsResponse GetSmartLists();
        SmartListsResponseWithRules GetSmartListById(long id, bool includeRules);
        SmartListsResponse GetSmartListByName(string name);
        SmartListDeleteResponse DeleteSmartList(long id);
    }
}