using Newtonsoft.Json;

namespace Marketo.ApiLibrary.Leads.BulkExportLeads.DTO
{
    public class ExportLeadFilterDto
    {
        [JsonProperty("createAt")]
        public DateRangeDto CreateAt { get; set; }
        [JsonProperty("smartListId")]
        public int SmartListId { get; set; }
        [JsonProperty("smartListName")]
        public string SmartListName { get; set; }
        [JsonProperty("staticListId")]
        public int StaticListId { get; set; }
        [JsonProperty("staticListName")]
        public string StaticListName { get; set; }
        [JsonProperty("updatedAt")]
        public DateRangeDto UpdatedAt { get; set; }
    }
}