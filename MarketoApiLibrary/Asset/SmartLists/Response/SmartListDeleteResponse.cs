using System.Collections.Generic;
using MarketoApiLibrary.Model;
using MarketoApiLibrary.Response;
using Newtonsoft.Json;

namespace MarketoApiLibrary.Asset.SmartLists.Response
{
    public class SmartListDeleteResponse : BaseResponse
    {
        [JsonProperty("result")]
        public List<IdResponse> Result { get; set; }
    }
}
