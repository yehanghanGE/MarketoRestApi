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
        private readonly GetFolderByIdProcessor _getFolderByIdProcessor;
        public FolderController(GetFoldersProcessor getFoldersProcessor,
            GetFolderByNameProcessor getFolderByNameProcessor, GetFolderByIdProcessor getFolderByIdProcessor)
        {
            _getFoldersProcessor = getFoldersProcessor;
            _getFolderByNameProcessor = getFolderByNameProcessor;
            _getFolderByIdProcessor = getFolderByIdProcessor;
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

        public FoldersResponse GetFolderById(int folderId, string folderType = "Folder")
        {
            var request = new GetFolderByIdRequest();
            request.FolderId = folderId;
            request.FolderType = folderType;
            var result = _getFolderByIdProcessor.Process(request);
            return result;
        }
    }
}
