using MarketoApiLibrary.Common.Model;

namespace MarketoApiLibrary.Asset.SmartLists.Request
{
    public class GetSmartListByIdRequest : BaseRequest
    {
        public long Id { get; set; }
        public bool IncludeRules { get; set; }
    }
}
