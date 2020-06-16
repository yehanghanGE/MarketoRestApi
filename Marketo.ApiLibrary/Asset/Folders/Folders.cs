using Marketo.ApiLibrary.Asset.Folders.Response;
using Marketo.ApiLibrary.Common.DI;

namespace Marketo.ApiLibrary.Asset.Folders
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
        /// <summary>
        /// GET /rest/asset/v1/folder/{id}.json
        /// </summary>
        /// <param name="folderId"></param>
        /// <param name="folderType"></param>
        /// <returns></returns>
        public static FoldersResponse GetFolderById(int folderId, string folderType)
        {
            return FolderController.GetFolderById(folderId, folderType);
        }

        /// <summary>
        /// GET /rest/asset/v1/folder/{id}/content.json
        /// </summary>
        /// <param name="folderId"></param>
        /// <returns></returns>
        public static FolderContentsResponse GetFolderContents(int folderId)
        {
            return FolderController.GetFolderContents(folderId);
        }

        /// <summary>
        /// POST /rest/asset/v1/folder/{id}/delete.json
        /// </summary>
        /// <param name="folderId"></param>
        /// <param name="folderType"></param>
        /// <returns></returns>
        public static FolderDeleteResponse DeleteFolder(int folderId, string folderType = "Folder")
        {
            return FolderController.DeleteFolder(folderId, folderType);
        }

        /// <summary>
        /// POST /rest/asset/v1/folders.json
        /// </summary>
        /// <param name="folderName"></param>
        /// <param name="description"></param>
        /// <param name="parentFolderId"></param>
        /// <param name="parentFolderType"></param>
        /// <returns></returns>
        public static FoldersResponse CreateFolder(string folderName, string description, int parentFolderId, string parentFolderType)
        {
            return FolderController.CreateFolder(folderName, description, parentFolderId, parentFolderType);
        }

        public static FoldersResponse UpdateFolderMetadata(int folderId, bool isArchive = true, string folderName = "", string folderType = "Type", string description = "")
        {
            return FolderController.UpdateFolderMetadata(folderId, description, isArchive, folderName, folderType);
        }
    }
}
