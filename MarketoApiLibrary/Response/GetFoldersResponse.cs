using System.Collections.Generic;
using MarketoApiLibrary.Model;
using Newtonsoft.Json;

namespace MarketoApiLibrary.Response
{
    public class GetFoldersResponse : BaseMarketoResponse
    {
        [JsonProperty("warnings")]
        public List<string> Warnings { get; set; }
        [JsonProperty("result")]
        public List<MarketoFolder> Result { get; set; }
    }
}
