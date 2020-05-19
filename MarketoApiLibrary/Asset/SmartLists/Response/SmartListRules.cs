using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Newtonsoft.Json;

namespace MarketoApiLibrary.Asset.SmartLists.Response
{
    public class SmartListRules
    {
        [JsonProperty("filterMatchType")]
        public string FilterMatchType { get; set; }
        [JsonProperty("triggers")]
        public string[] Triggers { get; set; }
        [JsonProperty("filters")]
        public List<SmartListFilters> Filters { get; set; }
    }
}
