using MarketoApiLibrary.Asset.Folders.Request;
using MarketoApiLibrary.Asset.Folders.RequestProcessor;
using MarketoApiLibrary.Asset.Folders.Response;
using MarketoApiLibrary.Common.Model;

namespace MarketoApiLibrary.Asset.Folders
{
    public class FolderController : IFolderController
    {
        private readonly GetFoldersProcessor _getFoldersProcessor;
        private readonly GetFolderByNameProcessor _getFolderByNameProcessor;

        public FolderController(GetFoldersProcessor getFoldersProcessor,
            GetFolderByNameProcessor getFolderByNameProcessor)
        {
            _getFoldersProcessor = getFoldersProcessor;
            _getFolderByNameProcessor = getFolderByNameProcessor;
        }

        public FoldersResponse GetFolders(int rootFolderId, string rootFolderType = "Folder")
        {
            var request = new GetFoldersRequest();
            var root = new Folder() { Id = rootFolderId, Type = rootFolderType };
            request.Root = root;
            var result = _getFoldersProcessor.Process(request);
            return result;
        }

        public FoldersResponse GetFolderByName(string folderName)
        {
            var request = new GetFolderByNameRequest();
            request.Name = folderName;
            var result = _getFolderByNameProcessor.Process(request);
            return result;
        }
    }
}
