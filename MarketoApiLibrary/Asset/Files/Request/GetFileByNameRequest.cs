using MarketoApiLibrary.Request;

namespace MarketoApiLibrary.Asset.Files.Request
{
    public class GetFileByNameRequest : BaseRequest
    {
        public string FileName { get; set; }
    }
}
