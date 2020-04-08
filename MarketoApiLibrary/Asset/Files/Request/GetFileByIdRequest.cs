using MarketoApiLibrary.Request;

namespace MarketoApiLibrary.Asset.Files.Request
{
    public class GetFileByIdRequest : BaseRequest
    {
        public string FileId { get; set; }
    }
}
