using System.Collections.Generic;
using MarketoApiLibrary.Common.Model;
using MarketoApiLibrary.Mis.Response;
using Newtonsoft.Json;

namespace MarketoApiLibrary.Asset.Folders.Response
{
    public class FoldersResponse : BaseResponse
    {
        [JsonProperty("result")]
        public List<FolderResponse> Result { get; set; }
    }
}
