using System.Collections.Generic;
using MarketoApiLibrary.Response;
using Newtonsoft.Json;

namespace MarketoApiLibrary.Asset.Folders.Response
{
    public class FoldersResponse : BaseMarketoResponse
    {
        [JsonProperty("result")]
        public List<FolderResponse> Result { get; set; }
    }
}
