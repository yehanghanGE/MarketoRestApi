using Marketo.ApiLibrary.Common.Model;
using Newtonsoft.Json;
using System.Collections.Generic;

namespace Marketo.ApiLibrary.Leads.BulkExportLeads.Response
{
    public abstract class BaseResponse : ApiModel
    {
        [JsonProperty("success")]
        public bool Success { get; set; }
        [JsonProperty("requestId")]
        public string RequestId { get; set; }
        [JsonProperty("errors")]
        public List<Error> Errors { get; set; }
        [JsonProperty("warnings")]
        public List<Warning> Warnings { get; set; }
    }
}
