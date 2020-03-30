using Newtonsoft.Json;
using System.Collections.Generic;

namespace MarketoApiLibrary.Model
{
    public class GetSmartListResponse : BaseMarketoResponse
    {
        [JsonProperty("result")]
        public List<MarketoSmartList> Result { get; set; }
    }
}
