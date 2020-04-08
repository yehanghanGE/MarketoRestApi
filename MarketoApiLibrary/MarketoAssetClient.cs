using System.Threading.Tasks;
using MarketoApiLibrary.Asset.Files;
using MarketoApiLibrary.Asset.Folders;
using MarketoApiLibrary.Asset.Folders.Response;
using MarketoApiLibrary.Provider;
using MarketoApiLibrary.Response;
using MarketoApiLibrary.Service;

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
            var request = _folderRequestFactory.CreateGetFolderByNameRequest(_host, _token, folderName,parentFolderId);
            var result = await FoldersHttpProcessor.GetFolderByName<T>(request);
            return result;
        }

        public Task<FoldersResponse> GetFolders(string rootFolderId)
        {
            var request = _folderRequestFactory.CreateGetFoldersRequest(_host, _token, rootFolderId);
            var folders = FoldersHttpProcessor.GetFolders<FoldersResponse>(request);
            return folders;
        }

        #endregion



    }
}
