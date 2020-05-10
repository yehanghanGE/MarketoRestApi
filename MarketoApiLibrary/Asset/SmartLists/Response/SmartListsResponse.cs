using MarketoApiLibrary.Common.Model;
using Newtonsoft.Json;
using System.Collections.Generic;

namespace MarketoApiLibrary.Asset.SmartLists.Response
{
    public class SmartListsResponse : BaseResponse
    {
        [JsonProperty("result")]
        public List<SmartListResponse> Result { get; set; }
    }
}
