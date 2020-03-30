using Newtonsoft.Json;
using System.Collections.Generic;

namespace MarketoApiLibrary.Model
{
    public class BaseMarketoResponse : IBaseMarketoResponse
    {
        [JsonProperty("success")]
        public bool Success { get; set; }
        [JsonProperty("requestId")]
        public string RequestId { get; set; }
        [JsonProperty("errors")]
        public List<Dictionary<string, object>> Errors { get; set; }
    }
}
