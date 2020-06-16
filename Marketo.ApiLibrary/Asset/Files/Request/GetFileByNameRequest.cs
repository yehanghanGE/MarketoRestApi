using Marketo.ApiLibrary.Common.Model;
using Marketo.ApiLibrary.Mis.Request;

namespace Marketo.ApiLibrary.Asset.Files.Request
{
    public class GetFileByNameRequest : BaseRequest
    {
        public string FileName { get; set; }
    }
}
