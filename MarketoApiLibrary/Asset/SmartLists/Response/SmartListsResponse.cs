using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MarketoApiLibrary.Asset.Files.Response;
using MarketoApiLibrary.Response;
using Newtonsoft.Json;

namespace MarketoApiLibrary.Asset.SmartLists.Response
{
    public class SmartListsResponse: BaseResponse
    {
        [JsonProperty("result")]
        public List<SmartListResponse> Result { get; set; }
    }
}
