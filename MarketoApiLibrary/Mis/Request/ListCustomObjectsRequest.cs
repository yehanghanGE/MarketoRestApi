using MarketoApiLibrary.Common.Model;

namespace MarketoApiLibrary.Mis.Request
{
    public class ListCustomObjectsRequest : BaseRequest
    {
        public string[] Names { get; set; }
    }
}
