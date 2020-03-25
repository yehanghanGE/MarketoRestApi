using Newtonsoft.Json;
using System.Collections.Generic;

namespace MarketoRestApiLibrary.Model
{
    public class GetFoldersResponse : BaseMarketoResponse
    {
        [JsonProperty("warnings")]
        public List<string> Warnings { get; set; }
        [JsonProperty("result")]
        public List<MarketoFolder> Result { get; set; }
    }
}
