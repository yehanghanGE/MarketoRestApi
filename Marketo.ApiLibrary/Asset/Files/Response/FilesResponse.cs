using System.Collections.Generic;
using Marketo.ApiLibrary.Common.Model;
using Marketo.ApiLibrary.Mis.Response;
using Newtonsoft.Json;

namespace Marketo.ApiLibrary.Asset.Files.Response
{
    public class FilesResponse : BaseResponse
    {
        [JsonProperty("result")]
        public List<FileResponse> Result { get; set; }
    }
}
