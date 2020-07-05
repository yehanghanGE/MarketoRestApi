using Newtonsoft.Json;

namespace Marketo.ApiLibrary.Leads.BulkExportLeads.DTO
{
    public class ColumnHeaderNamesDto
    {
        [JsonProperty("name")]
        public virtual string Name { get; set; }
        [JsonProperty("value")]
        public virtual string Value { get; set; }
    }
}