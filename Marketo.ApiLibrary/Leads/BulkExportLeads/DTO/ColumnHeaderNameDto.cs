using Newtonsoft.Json;

namespace Marketo.ApiLibrary.Leads.BulkExportLeads.DTO
{
    public class ColumnHeaderNameDto
    {
        [JsonProperty("name")]
        public string Name { get; set; }
        [JsonProperty("value")]
        public string Value { get; set; }
    }
}