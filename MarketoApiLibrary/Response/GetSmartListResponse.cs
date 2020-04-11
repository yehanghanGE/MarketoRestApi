using System.Collections.Generic;
using MarketoApiLibrary.Model;
using Newtonsoft.Json;

namespace MarketoApiLibrary.Response
{
    public class GetSmartListResponse : BaseResponse
    {
        [JsonProperty("result")]
        public List<MarketoSmartList> Result { get; set; }
    }
}
