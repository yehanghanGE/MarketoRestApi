using MarketoApiLibrary.Asset.Files;
using MarketoApiLibrary.Asset.Folders;
using MarketoApiLibrary.Provider;
using System.Threading.Tasks;

namespace MarketoApiLibrary
{
    public class MarketoAssetClient
    {
        private readonly string _host;
        private readonly string _token;
        private readonly IFilesRequestFactory _fileRequestFactory;
        private readonly IFoldersRequestFactory _folderRequestFactory;

        public MarketoAssetClient(string host, string clientId, string clientSecret)
        {
            _host = host;
            ITokenProvider tokenProvider = new TokenProvider();
            _token = tokenProvider.GetTokenAsync(host, clientId, clientSecret).Result;
            _fileRequestFactory = new FilesRequestFactory();
            _folderRequestFactory = new FoldersRequestFactory();
        }

        #region FilesController

        public async Task<T> GetFileByName<T>(string fileName)
        {
            var request = _fileRequestFactory.CreateGetFileByNameRequest(_host, _token, fileName);
            var result = await FilesHttpProcessor.GetFileByName<T>(request);
            return result;
        }

        public async Task<T> GetFileById<T>(int fileId)
        {
            var request = _fileRequestFactory.CreateGetFileByIdRequest(_host, _token, fileId);
            var result = await FilesHttpProcessor.GetFileById<T>(request);
            return result;
        }


        public async Task<T> GetFiles<T>(string folderId, int offSet)
        {
            var request = _fileRequestFactory.CreateGetFilesRequest(_host, _token, folderId, offSet);
            var result = await FilesHttpProcessor.GetFiles<T>(request);
            return result;
        }

        public async Task<T> CreateFile<T>(string filePath)
        {
            var request = _fileRequestFactory.CreateCreateFileRequest(_host, _token, filePath);
            var result = await FilesHttpProcessor.CreateFile<T>(request);
            return result;
        }

        public async Task<T> UpdateFile<T>(string filePath, string fileId)
        {
            var request = _fileRequestFactory.CreateUpdateFileRequest(_host, _token, filePath, fileId);
            var result = await FilesHttpProcessor.UpdateFile<T>(request);
            return result;
        }

        #endregion

        #region FoldersController
        public async Task<T> GetFolderByName<T>(string folderName, int parentFolderId)
        {
            var request = _folderRequestFactory.CreateGetFolderByNameRequest(_host, _token, folderName, parentFolderId);
            var result = await FoldersHttpProcessor.GetFolderByName<T>(request);
            return result;
        }
        public async Task<T> GetFolderById<T>(int folderId)
        {
            var request = _folderRequestFactory.CreateGetFolderByIdRequest(_host, _token, folderId);
            var result = await FoldersHttpProcessor.GetFolderById<T>(request);
            return result;
        }
        public async Task<T> GetFolderContents<T>(int folderId)
        {
            var request = _folderRequestFactory.CreateGetFolderContentsRequest(_host, _token, folderId);
            var result = await FoldersHttpProcessor.GetFolderContents<T>(request);
            return result;
        }
        public async Task<T> GetFolders<T>(int rootFolderId)
        {
            var request = _folderRequestFactory.CreateGetFoldersRequest(_host, _token, rootFolderId);
            var result = await FoldersHttpProcessor.GetFolders<T>(request);
            return result;
        }
        public async Task<T> CreateFolder<T>(string folderName, int parentFolderId, string parentFolderType)
        {
            var request = _folderRequestFactory.CreateCreateFolderRequest(_host, _token, folderName, parentFolderId, parentFolderType);
            var result = await FoldersHttpProcessor.CreateFolder<T>(request);
            return result;
        }
        public async Task<T> UpdateFolderMetadata<T>(int folderId, string folderName = null, string folderType = null, string description = null, bool isArchive = false)
        {
            var request = _folderRequestFactory.CreateUpdateFolderMetadataRequest(_host, _token, folderId, folderName, description:description);
            var result = await FoldersHttpProcessor.UpdateFolderMetadata<T>(request);
            return result;
        }
        public async Task<T> DeleteFolder<T>(int folderId)
        {
            var request = _folderRequestFactory.CreateDeleteFolderRequest(_host, _token, folderId);
            var result = await FoldersHttpProcessor.DeleteFolder<T>(request);
            return result;
        }
        #endregion
    }
}
