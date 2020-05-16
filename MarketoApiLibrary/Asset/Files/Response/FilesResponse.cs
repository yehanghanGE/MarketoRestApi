using System.Collections.Generic;
using MarketoApiLibrary.Common.Model;
using MarketoApiLibrary.Mis.Response;
using Newtonsoft.Json;

namespace MarketoApiLibrary.Asset.Files.Response
{
    public class FilesResponse : BaseResponse
    {
        [JsonProperty("result")]
        public List<FileResponse> Result { get; set; }
    }
}
