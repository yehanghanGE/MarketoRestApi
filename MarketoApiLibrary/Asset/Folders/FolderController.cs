using MarketoApiLibrary.Asset.Folders.Request;
using MarketoApiLibrary.Asset.Folders.RequestProcessor;
using MarketoApiLibrary.Asset.Folders.Response;
using MarketoApiLibrary.Common.Model;

namespace MarketoApiLibrary.Asset.Folders
{
    public class FolderController : IFolderController
    {
        private readonly GetFoldersProcessor _getFoldersProcessor;

        public FolderController(GetFoldersProcessor getFoldersProcessor)
        {
            _getFoldersProcessor = getFoldersProcessor;
        }

        public FoldersResponse GetFolders(int rootFolderId, string rootFolderType = "Folder")
        {
            var request = new GetFoldersRequest();
            var root = new Folder() { Id = rootFolderId, Type = rootFolderType };
            request.Root = root;
            var result = _getFoldersProcessor.Process(request);
            return result;
        }
    }
}
