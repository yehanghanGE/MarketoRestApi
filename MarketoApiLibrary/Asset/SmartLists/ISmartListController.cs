using MarketoApiLibrary.Asset.SmartLists.Response;
using System.Threading.Tasks;

namespace MarketoApiLibrary.Asset.SmartLists
{
    public interface ISmartListController
    {
        SmartListsResponse GetSmartLists();
        SmartListsResponseWithRules GetSmartListById(long id, bool includeRules);
    }
}