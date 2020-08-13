using Newtonsoft.Json;
using System.Collections.Generic;

namespace Marketo.ApiLibrary.Leads.BulkExportLeads.DTO
{
    public class ExportLeadDto
    {
        [JsonProperty("columnHeaderNames")]
        public List<ColumnHeaderNameDto> ColumnHeaderNames { get; set; }
        [JsonProperty("fields")]
        public List<string> Fields { get; set; }
        [JsonProperty("filter")]
        public ExportLeadFilterDto Filter { get; set; }
        [JsonProperty("format")]
        public string Format { get; set; }
    }
}
