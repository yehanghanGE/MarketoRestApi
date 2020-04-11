using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MarketoApiLibrary.Response;
using Newtonsoft.Json;

namespace MarketoApiLibrary.Asset.Folders.Response
{
    public class FolderContentsResponse: BaseResponse
    {
        [JsonProperty("result")]
        public List<FolderContentResponse> Result { get; set; }
    }
}
