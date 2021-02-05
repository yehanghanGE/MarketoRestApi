using Newtonsoft.Json;

namespace Marketo.ApiLibrary.Lead.Leads.Response
{
    public class LeadAttribute
    {
        [JsonProperty("dataType")]
        public string DataType { get; set; }
        [JsonProperty("displayName")]
        public string DisplayName { get; set; }
        [JsonProperty("id")]
        public int Id { get; set; }
        [JsonProperty("length")]
        public int Length { get; set; }
        [JsonProperty("rest")]
        public LeadMapAttribute Rest { get; set; }
        [JsonProperty("soap")]
        public LeadMapAttribute Soap { get; set; }
    }
}
