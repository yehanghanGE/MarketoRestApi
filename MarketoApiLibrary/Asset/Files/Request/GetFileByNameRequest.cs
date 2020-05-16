using MarketoApiLibrary.Common.Model;
using MarketoApiLibrary.Mis.Request;

namespace MarketoApiLibrary.Asset.Files.Request
{
    public class GetFileByNameRequest : BaseRequest
    {
        public string FileName { get; set; }
    }
}
