using Marketo.ApiLibrary.Common.Model;
using Marketo.ApiLibrary.Mis.Request;

namespace Marketo.ApiLibrary.Asset.SmartLists.Request
{
    public class DeleteSmartListRequest: BaseRequest
    {
        public long Id { get; set; }
    }
}