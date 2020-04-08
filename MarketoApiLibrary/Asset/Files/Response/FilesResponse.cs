using System.Collections.Generic;
using MarketoApiLibrary.Response;
using Newtonsoft.Json;

namespace MarketoApiLibrary.Asset.Files.Response
{
    public class FilesResponse : BaseMarketoResponse
    {
        [JsonProperty("result")]
        public List<FileResponse> Result { get; set; }
    }
}
