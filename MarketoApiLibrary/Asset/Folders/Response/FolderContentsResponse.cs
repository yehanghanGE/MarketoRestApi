using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MarketoApiLibrary.Common.Model;
using MarketoApiLibrary.Mis.Response;
using Newtonsoft.Json;

namespace MarketoApiLibrary.Asset.Folders.Response
{
    public class FolderContentsResponse: BaseResponse
    {
        [JsonProperty("result")]
        public List<FolderContentResponse> Result { get; set; }
    }
}
