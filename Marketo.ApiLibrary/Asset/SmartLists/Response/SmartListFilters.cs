using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Newtonsoft.Json;

namespace Marketo.ApiLibrary.Asset.SmartLists.Response
{
    public class SmartListFilters
    {
        [JsonProperty("id")]
        public int Id { get; set; }
        [JsonProperty("name")]
        public string Name { get; set; }
        [JsonProperty("ruleTypeId")]
        public int RuleTypeId { get; set; }
        [JsonProperty("ruleType")]
        public string RuleType { get; set; }
        [JsonProperty("operator")]
        public string Operator { get; set; }
        [JsonProperty("conditions")]
        public List<SmartListConditions> Conditions { get; set; }
    }
}
