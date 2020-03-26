using System.Collections.Generic;

namespace MarketoRestApiLibrary.Model
{
    public interface IBaseMarketoResponse
    {
        List<Dictionary<string, object>> Errors { get; set; }
        string RequestId { get; set; }
        bool Success { get; set; }
    }
}