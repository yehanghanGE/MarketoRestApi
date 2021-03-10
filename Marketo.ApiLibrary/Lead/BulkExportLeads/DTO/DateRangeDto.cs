using Newtonsoft.Json;

namespace Marketo.ApiLibrary.Lead.BulkExportLeads.DTO
{
    public class DateRangeDto
    {
        [JsonProperty("endAt")]
        public string EndAt { get; set; }
        [JsonProperty("startAt")]
        public string StartAt { get; set; }
    }
}