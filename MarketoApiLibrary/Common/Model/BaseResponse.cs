using System.Collections.Generic;
using MarketoApiLibrary.Mis.Response;
using Newtonsoft.Json;

namespace MarketoApiLibrary.Common.Model
{
    public abstract class BaseResponse:ApiModel
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
