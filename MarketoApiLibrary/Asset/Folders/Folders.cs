using MarketoApiLibrary.Asset.Folders.Response;
using MarketoApiLibrary.Common.DI;

namespace MarketoApiLibrary.Asset.Folders
{
    public class Folders
    {
        private static IFolderController _folderController;
        public static IFolderController FolderController
        {
            get
            {
                if (_folderController == null)
                {
                    Initialize();
                }

                return _folderController;
            }
        }

        static Folders()
        {
            Initialize();
        }
        private static void Initialize()
        {
            _folderController = MarketoApiContainer.Resolve<IFolderController>();
        }
        /// <summary>
        /// GET /rest/asset/v1/folders.json
        /// </summary>
        /// <returns></returns>
        public static FoldersResponse GetFolders(int parentFolderId, string parentFolderType)
        {
            return FolderController.GetFolders(parentFolderId, parentFolderType);
        }
        /// <summary>
        /// GET /rest/asset/v1/folder/byName.json
        /// </summary>
        /// <param name="folderName"></param>
        /// <returns></returns>
        public static FoldersResponse GetFolderByName(string folderName)
        {
            return FolderController.GetFolderByName(folderName);
        }
    }
}
