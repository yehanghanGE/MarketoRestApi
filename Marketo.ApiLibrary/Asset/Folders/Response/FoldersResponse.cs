using Marketo.ApiLibrary.Common.Model;
using Newtonsoft.Json;
using System.Collections.Generic;

namespace Marketo.ApiLibrary.Asset.Folders.Response
{
    public class FoldersResponse : BaseResponse
    {
        [JsonProperty("result")]
        public List<FolderResponse> Result { get; set; }
    }
}
