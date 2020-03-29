using Newtonsoft.Json;
using System.Collections.Generic;

namespace MarketoApiLibrary.Model
{
    public class GetFilesResponse : BaseMarketoResponse
    {
        [JsonProperty("result")]
        public List<MarketoFile> Result { get; set; }
    }
}
