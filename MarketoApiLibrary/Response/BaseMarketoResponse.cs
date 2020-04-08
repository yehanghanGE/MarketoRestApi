using MarketoApiLibrary.Model;
using Newtonsoft.Json;
using System.Collections.Generic;

namespace MarketoApiLibrary.Response
{
    public class BaseMarketoResponse : IBaseMarketoResponse
    {
        [JsonProperty("success")]
        public bool Success { get; set; }
        [JsonProperty("requestId")]
        public string RequestId { get; set; }
        [JsonProperty("errors")]
        public List<Error> Errors { get; set; }
        [JsonProperty("warnings")]
        public List<string> Warnings { get; set; }
    }
}
