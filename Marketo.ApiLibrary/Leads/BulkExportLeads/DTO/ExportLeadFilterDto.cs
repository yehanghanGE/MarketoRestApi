using Newtonsoft.Json;

namespace Marketo.ApiLibrary.Leads.BulkExportLeads.DTO
{
    public class ExportLeadFilterDto
    {
        [JsonProperty("createAt")]
        public virtual DateRangeDto CreateAt { get; set; }
        [JsonProperty("smartListId")]
        public virtual int SmartListId { get; set; }
        [JsonProperty("smartListName")]
        public virtual string SmartListName { get; set; }
        [JsonProperty("staticListId")]
        public virtual int StaticListId { get; set; }
        [JsonProperty("staticListName")]
        public virtual string StaticListName { get; set; }
        [JsonProperty("updatedAt")]
        public virtual DateRangeDto UpdatedAt { get; set; }
    }
}