using System.Collections.Generic;
using Marketo.ApiLibrary.Common.Model;
using Newtonsoft.Json;

namespace Marketo.ApiLibrary.Mis.Response
{
    public class GetSmartListResponse : BaseResponse
    {
        [JsonProperty("result")]
        public List<MarketoSmartList> Result { get; set; }
    }
}
