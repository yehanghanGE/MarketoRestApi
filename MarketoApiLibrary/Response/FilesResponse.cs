using System.Collections.Generic;
using MarketoApiLibrary.Model;
using Newtonsoft.Json;

namespace MarketoApiLibrary.Response
{
    public class FilesResponse : BaseMarketoResponse
    {
        [JsonProperty("result")]
        public List<FileResponse> Result { get; set; }
    }
}
