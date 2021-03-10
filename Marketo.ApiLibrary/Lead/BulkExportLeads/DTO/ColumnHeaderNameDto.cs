using Newtonsoft.Json;

namespace Marketo.ApiLibrary.Lead.BulkExportLeads.DTO
{
    public class ColumnHeaderNameDto
    {
        [JsonProperty("name")]
        public string Name { get; set; }
        [JsonProperty("value")]
        public string Value { get; set; }
    }
}