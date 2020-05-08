using MarketoApiLibrary.Request;

namespace MarketoApiLibrary.Asset.SmartLists.Request
{
    public class GetSmartListByNameRequest: BaseRequest
    {
        public string Name { get; set; }
    }
}