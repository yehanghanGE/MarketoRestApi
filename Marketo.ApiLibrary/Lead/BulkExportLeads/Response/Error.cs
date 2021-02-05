using Newtonsoft.Json;

namespace Marketo.ApiLibrary.Lead.BulkExportLeads.Response
{
    public class Error
    {
        [JsonProperty("code")]
        public int Code { get; set; }
        [JsonProperty("message")]
        public string Message { get; set; }
    }
}
