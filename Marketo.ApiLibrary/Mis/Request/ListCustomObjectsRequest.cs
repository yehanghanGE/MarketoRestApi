using Marketo.ApiLibrary.Common.Model;

namespace Marketo.ApiLibrary.Mis.Request
{
    public class ListCustomObjectsRequest : BaseRequest
    {
        public string[] Names { get; set; }
    }
}
