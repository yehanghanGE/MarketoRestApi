using Newtonsoft.Json;

namespace Marketo.ApiLibrary.Leads.BulkExportLeads.DTO
{
    public class DateRangeDto
    {
        [JsonProperty("endAt")]
        public virtual string EndAt { get; set; }
        [JsonProperty("startAt")]
        public virtual string StartAt { get; set; }
    }
}