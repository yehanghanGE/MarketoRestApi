using System.Collections.Generic;

namespace MarketoApiLibrary.Request
{
    public class GetFileByNameRequest : BaseRequest
    {
        public string FileName { get; set; }
    }
}
