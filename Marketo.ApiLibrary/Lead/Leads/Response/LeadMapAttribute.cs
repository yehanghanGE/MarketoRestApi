using Newtonsoft.Json;

namespace Marketo.ApiLibrary.Lead.Leads.Response
{
    public class LeadMapAttribute
    {
        [JsonProperty("name")]
        public string Name { get; set; }

        [JsonProperty("readOnly")]
        public bool ReadOnly { get; set; }
    }
}