using MarketoApiLibrary.Common.Model;
using MarketoApiLibrary.Mis.Request;

namespace MarketoApiLibrary.Asset.Files.Request
{
    public class GetFileByIdRequest : BaseRequest
    {
        public string FileId { get; set; }
    }
}
