using Newtonsoft.Json;

namespace Marketo.ApiLibrary.Lead.BulkExportLeads.Response
{
    public class ExportResponse
    {
        [JsonProperty("createdAt")]
        public string CreatedAt { get; set; }
        [JsonProperty("errorMsg ")]
        public string ErrorMsg { get; set; }
        [JsonProperty("exportId ")]
        public string ExportId { get; set; }
        [JsonProperty("fileSize")]
        public int FileSize { get; set; }
        [JsonProperty("fileChecksum ")]
        public string FileChecksum { get; set; }
        [JsonProperty("finishedAt")]
        public string FinishedAt { get; set; }
        [JsonProperty("format")]
        public string Format { get; set; }
        [JsonProperty("numberOfRecords")]
        public int NumberOfRecords { get; set; }
        [JsonProperty("queuedAt")]
        public string QueuedAt { get; set; }
        [JsonProperty("startedAt")]
        public string StartedAt { get; set; }
        [JsonProperty("status")]
        public string Status { get; set; }
    }
}
