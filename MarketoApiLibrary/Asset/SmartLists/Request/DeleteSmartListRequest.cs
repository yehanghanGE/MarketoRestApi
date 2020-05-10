using MarketoApiLibrary.Common.Model;
using MarketoApiLibrary.Mis.Request;

namespace MarketoApiLibrary.Asset.SmartLists.Request
{
    public class DeleteSmartListRequest: BaseRequest
    {
        public long Id { get; set; }
    }
}