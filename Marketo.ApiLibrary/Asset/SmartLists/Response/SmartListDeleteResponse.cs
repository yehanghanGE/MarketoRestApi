using System.Collections.Generic;
using Marketo.ApiLibrary.Common.Model;
using Marketo.ApiLibrary.Mis.Response;
using Newtonsoft.Json;

namespace Marketo.ApiLibrary.Asset.SmartLists.Response
{
    public class SmartListDeleteResponse : BaseResponse
    {
        [JsonProperty("result")]
        public List<IdResponse> Result { get; set; }
    }
}
