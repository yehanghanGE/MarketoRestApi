using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MarketoRestApiLibrary.Model
{
    public class GetSmartListResponse : BaseMarketoResponse
    {
        [JsonProperty("result")]
        public List<MarketoSmartList> Result { get; set; }
    }
}
