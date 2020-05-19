using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Newtonsoft.Json;

namespace MarketoApiLibrary.Asset.SmartLists.Response
{
    public class SmartListConditions
    {
        [JsonProperty("activityAttributeId")]
        public int ActivityAttributeId { get; set; }
        [JsonProperty("activityAttributeName")]
        public string ActivityAttributeName { get; set; }
        [JsonProperty("operator")]
        public string Operator  { get; set; }
        [JsonProperty("values")]
        public string[] Values { get; set; }
        [JsonProperty("isPrimary")]
        public bool IsPrimary { get; set; }
    }
}
