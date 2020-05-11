using MarketoApiLibrary.Common.Model;
using MarketoApiLibrary.Mis.Request;

namespace MarketoApiLibrary.Asset.Files.Request
{
    public class UpdateFileRequest: BaseRequest
    {
        public string FileId  { get; set; }
        public string FilePath { get; set; }
    }
}
