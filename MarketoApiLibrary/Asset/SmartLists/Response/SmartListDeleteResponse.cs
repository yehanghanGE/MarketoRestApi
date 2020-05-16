using System.Collections.Generic;
using MarketoApiLibrary.Common.Model;
using MarketoApiLibrary.Mis.Response;
using Newtonsoft.Json;

namespace MarketoApiLibrary.Asset.SmartLists.Response
{
    public class SmartListDeleteResponse : BaseResponse
    {
        [JsonProperty("result")]
        public List<IdResponse> Result { get; set; }
    }
}
