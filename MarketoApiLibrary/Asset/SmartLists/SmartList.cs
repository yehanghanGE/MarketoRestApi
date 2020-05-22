﻿using MarketoApiLibrary.Asset.SmartLists.Response;
using MarketoApiLibrary.Common.DI;

namespace MarketoApiLibrary.Asset.SmartLists
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
    }
}
