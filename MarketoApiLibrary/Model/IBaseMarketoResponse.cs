using System.Collections.Generic;

namespace MarketoApiLibrary.Model
{
    public interface IBaseMarketoResponse
    {
        List<Dictionary<string, object>> Errors { get; set; }
        string RequestId { get; set; }
        bool Success { get; set; }
    }
}