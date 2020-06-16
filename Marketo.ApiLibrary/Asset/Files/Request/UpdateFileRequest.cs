using Marketo.ApiLibrary.Common.Model;
using Marketo.ApiLibrary.Mis.Request;

namespace Marketo.ApiLibrary.Asset.Files.Request
{
    public class UpdateFileRequest: BaseRequest
    {
        public string FileId  { get; set; }
        public string FilePath { get; set; }
    }
}
