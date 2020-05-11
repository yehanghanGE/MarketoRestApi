using System.Collections.Generic;
using MarketoApiLibrary.Common.Model;
using Newtonsoft.Json;

namespace MarketoApiLibrary.Mis.Response
{
    public class GetSmartListResponse : BaseResponse
    {
        [JsonProperty("result")]
        public List<MarketoSmartList> Result { get; set; }
    }
}
