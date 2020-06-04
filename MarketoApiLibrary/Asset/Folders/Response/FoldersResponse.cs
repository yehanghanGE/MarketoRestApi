using MarketoApiLibrary.Common.Model;
using Newtonsoft.Json;
using System.Collections.Generic;

namespace MarketoApiLibrary.Asset.Folders.Response
{
    public class FoldersResponse : BaseResponse
    {
        [JsonProperty("result")]
        public List<FolderResponse> Result { get; set; }
    }
}
