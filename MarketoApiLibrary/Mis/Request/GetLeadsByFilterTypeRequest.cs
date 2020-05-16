using MarketoApiLibrary.Common.Model;

namespace MarketoApiLibrary.Mis.Request
{
    public class GetLeadsByFilterTypeRequest : BaseRequest
    {
        public string FilterType { get; set; }
        public string[] FilterValues { get; set; }
        public string[] Fields { get; set; }
        public int BatchSize { get; set; }
        public string NextPageToken { get; set; }
    }
}