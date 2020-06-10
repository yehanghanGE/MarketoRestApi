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
        private readonly GetFolderContentsProcessor _getFolderContentsProcessor;
        private readonly DeleteFolderProcessor _deleteFolderProcessor;
        private readonly CreateFolderProcessor _createFolderProcessor;
        public FolderController(GetFoldersProcessor getFoldersProcessor,
            GetFolderByNameProcessor getFolderByNameProcessor, GetFolderByIdProcessor getFolderByIdProcessor, GetFolderContentsProcessor getFolderContentsProcessor, DeleteFolderProcessor deleteFolderProcessor, CreateFolderProcessor craeteFolderProcessor)
        {
            _getFoldersProcessor = getFoldersProcessor;
            _getFolderByNameProcessor = getFolderByNameProcessor;
            _getFolderByIdProcessor = getFolderByIdProcessor;
            _getFolderContentsProcessor = getFolderContentsProcessor;
            _deleteFolderProcessor = deleteFolderProcessor;
            _createFolderProcessor = craeteFolderProcessor;
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
            var request = new GetFolderByNameRequest { Name = folderName };
            var result = _getFolderByNameProcessor.Process(request);
            return result;
        }

        public FoldersResponse GetFolderById(int folderId, string folderType = "Folder")
        {
            var request = new GetFolderByIdRequest { FolderId = folderId, FolderType = folderType };
            var result = _getFolderByIdProcessor.Process(request);
            return result;
        }

        public FolderContentsResponse GetFolderContents(int folderId, int maxReturn = 20, int offset = 20, string folderType = "Folder")
        {
            var request = new GetFolderContentsRequest
            {
                FolderId = folderId,
                MaxReturn = maxReturn,
                Offset = offset,
                FolderType = folderType
            };
            var result = _getFolderContentsProcessor.Process(request);
            return result;
        }

        public FolderDeleteResponse DeleteFolder(int folderId, string folderType)
        {
            var request = new DeleteFolderRequest { FolderId = folderId, FolderType = folderType };
            var result = _deleteFolderProcessor.Process(request);
            return result;
        }

        public FoldersResponse CreateFolder(string folderName, string description, int parentFolderId, string parentFolderType)
        {
            var request = new CreateFolderRequest
            {
                FolderName = folderName,
                Description = description,
                Parent = new Folder() { Id = parentFolderId, Type = parentFolderType }
            };
            var result = _createFolderProcessor.Process(request);
            return result;
        }
    }
}
