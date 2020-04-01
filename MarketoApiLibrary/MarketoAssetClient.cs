using System.Threading.Tasks;
using MarketoApiLibrary.Model;
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

        public MarketoAssetClient(string host, string clientId, string clientSecret)
        {
            _host = host;
            ITokenProvider tokenProvider = new TokenProvider();
            _token = tokenProvider.GetTokenAsync(host, clientId, clientSecret).Result;
            _fileRequestFactory = new FilesRequestFactory();
        }

        // Files
        /// <summary>
        /// GET /rest/asset/v1/file/byName.json
        /// </summary>
        /// <param name="fileName"></param>
        /// <returns></returns>
        public async Task<T> GetFileByName<T>(string fileName)
        {
            var request = _fileRequestFactory.CreateGetFileByNameRequest(_host, _token, fileName);
            var result = await FilesHttpProcessor.GetFileByName<T>(request);
            return result;
        }
        /// <summary>
        /// GET /rest/asset/v1/file/{id}.json
        /// </summary>
        /// <param name="fileId"></param>
        public async Task<T> GetFileById<T>(int fileId)
        {
            var request = _fileRequestFactory.CreateGetFileByIdRequest(_host, _token, fileId);
            var result = await FilesHttpProcessor.GetFileById<T>(request);
            return result;
        }

        /// <summary>
        /// GET /rest/asset/v1/files.json
        /// </summary>
        /// <param name="folderId"></param>
        /// <param name="offSet"></param>
        /// <returns></returns>
        public async Task<FilesResponse> GetFiles(string folderId, int offSet)
        {
            var request = _fileRequestFactory.CreateGetFilesRequest(_host, _token, folderId, offSet);
            var result = await FilesHttpProcessor.GetFiles(request);
            return result;
        }
        
        public void CreateFile()
        {

        }
      
    }
}
