using System.Collections.Generic;

namespace MarketoApiLibrary.Request
{
    public class GetFileByIdRequest : BaseRequest
    {
        public string FileId { get; set; }
    }
}
