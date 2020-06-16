using Marketo.ApiLibrary.Common.Model;

namespace Marketo.ApiLibrary.Asset.SmartLists.Request
{
    public class GetSmartListByIdRequest : BaseRequest
    {
        public long Id { get; set; }
        public bool IncludeRules { get; set; }
    }
}
