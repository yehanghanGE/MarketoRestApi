using System.Collections.Generic;
using MarketoApiLibrary.Common.Model;
using MarketoApiLibrary.Mis.Request;

namespace MarketoApiLibrary.Asset.SmartLists.Request
{
    public class GetSmartListsRequest : BaseRequest
    {
        public Dictionary<string, dynamic> Folder = new Dictionary<string, dynamic>();
        public int Offset { get; set; } //integer offset for paging
        public int MaxReturn { get; set; } //maximum number of returned results, max 200, default 20
        public string EarliestUpdatedAt { get; set; } //Exclude smart lists prior to this date. Must be valid ISO-8601 string. See Datetime field type description.
        public string LatestUpdatedAt { get; set; }
    }
}
