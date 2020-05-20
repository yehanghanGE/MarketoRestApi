using MarketoApiLibrary.Common.Model;
using Newtonsoft.Json;
using System.Collections.Generic;

namespace MarketoApiLibrary.Asset.SmartLists.Response
{
    public class SmartListsResponseWithRules : BaseResponse
    {
        [JsonProperty("result")]
        public List<SmartListResponseWithRules> Result { get; set; }
    }
}
