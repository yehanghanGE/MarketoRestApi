using System.Collections.Generic;
using MarketoApiLibrary.Request;

namespace MarketoApiLibrary.Asset.SmartLists.Request
{
    public class GetSmartListByIdRequest : BaseRequest
    {
        public long Id { get; set; }
        public bool IncludeRules { get; set; }
    }
}
