using Newtonsoft.Json;
using System.Collections.Generic;

namespace Marketo.ApiLibrary.Leads.BulkExportLeads.Response
{
    public class CreateExportLeadJobResponse : BaseResponse
    {
        [JsonProperty("result")]
        public List<ExportResponse> Result { get; set; }
    }
}
