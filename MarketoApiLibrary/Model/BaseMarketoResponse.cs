using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MarketoRestApiLibrary.Model
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
