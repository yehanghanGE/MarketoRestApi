using Marketo.ApiLibrary.Asset.SmartLists.Response;

namespace Marketo.ApiLibrary.Asset.SmartLists
{
    public interface ISmartListController
    {
        SmartListsResponse GetSmartLists();
        SmartListsResponseWithRules GetSmartListById(long id, bool includeRules);
        SmartListsResponse GetSmartListByName(string name);
        SmartListDeleteResponse DeleteSmartList(long id);
        SmartListsResponse CloneSmartList(int id, string clonedSmartListName, int parentFolderId, string parentFolderType, string description);
    }
}