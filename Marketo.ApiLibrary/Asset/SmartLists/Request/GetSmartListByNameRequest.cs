using Marketo.ApiLibrary.Common.Model;
using Marketo.ApiLibrary.Mis.Request;

namespace Marketo.ApiLibrary.Asset.SmartLists.Request
{
    public class GetSmartListByNameRequest: BaseRequest
    {
        public string Name { get; set; }
    }
}