using Marketo.ApiLibrary.Asset.SmartLists.Response;
using Marketo.ApiLibrary.Common.DI;

namespace Marketo.ApiLibrary.Asset.SmartLists
{
    public class SmartList
    {
        private static ISmartListController _smartListController;

        public static ISmartListController SmartListController
        {
            get
            {
                if (_smartListController == null)
                {
                    Initialize();
                }

                return _smartListController;
            }
        }

        static SmartList()
        {
            Initialize();
        }

        private static void Initialize()
        {
            _smartListController = MarketoApiContainer.Resolve<ISmartListController>();
        }
        /// <summary>
        /// GET /rest/asset/v1/smartLists.json
        /// </summary>
        /// <returns></returns>
        public static SmartListsResponse GetSmartList()
        {
            return SmartListController.GetSmartLists();
        }
        /// <summary>
        /// GET /rest/asset/v1/smartList/{id}.json
        /// </summary>
        /// <param name="id"></param>
        /// <param name="includeRules"></param>
        /// <returns></returns>

        public static SmartListsResponseWithRules GetSmartListById(long id, bool includeRules)
        {
            return SmartListController.GetSmartListById(id, includeRules);
        }
        /// <summary>
        /// GET /rest/asset/v1/smartList/byName.json
        /// </summary>
        /// <param name="name"></param>
        /// <returns></returns>
        public static SmartListsResponse GetSmartListByName(string name)
        {
            return SmartListController.GetSmartListByName(name);
        }

        /// <summary>
        /// POST /rest/asset/v1/smartList/{id}/delete.json
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        public static SmartListDeleteResponse DeleteSmartList(long id)
        {
            return SmartListController.DeleteSmartList(id);
        }

        /// <summary>
        /// POST /rest/asset/v1/smartList/{id}/clone.json
        /// </summary>
        /// <param name="id"></param>
        /// <param name="clonedSmartListName"></param>
        /// <param name="parentFolderId"></param>
        /// <param name="parentFolderType"></param>
        /// <param name="description"></param>
        /// <returns></returns>
        public static SmartListsResponse CloneSmartList(int id, string clonedSmartListName, int parentFolderId, string parentFolderType = "Folder", string description = "")
        {
            return SmartListController.CloneSmartList(id, clonedSmartListName, parentFolderId, parentFolderType, description);
        }
    }
}
