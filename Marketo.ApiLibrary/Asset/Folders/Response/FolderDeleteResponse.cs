using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Marketo.ApiLibrary.Common.Model;
using Marketo.ApiLibrary.Mis.Response;
using Newtonsoft.Json;

namespace Marketo.ApiLibrary.Asset.Folders.Response
{
    public class FolderDeleteResponse: BaseResponse
    {
        [JsonProperty("result")]
        public List<IdResponse> Result { get; set; }
    }
}
