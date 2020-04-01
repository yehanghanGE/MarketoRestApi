using System.Collections.Generic;
using MarketoApiLibrary.Model;
using Newtonsoft.Json;

namespace MarketoApiLibrary.Response
{
    public class GetSmartListResponse : BaseMarketoResponse
    {
        [JsonProperty("result")]
        public List<MarketoSmartList> Result { get; set; }
    }
}
