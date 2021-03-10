using Marketo.ApiLibrary.Common.Model;
using Newtonsoft.Json;
using System.Collections.Generic;

namespace Marketo.ApiLibrary.Lead.Leads.Response
{
    public class LeadAttributeResponse : BaseResponse
    {
        [JsonProperty("moreResult")]
        public bool MoreResult { get; set; }

        [JsonProperty("nextPageToken")]
        public string NextPageToken { get; set; }

        [JsonProperty("result")]
        public List<LeadAttribute> Result { get; set; }
    }
}
