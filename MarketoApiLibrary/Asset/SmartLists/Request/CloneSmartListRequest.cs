using System.Security.AccessControl;
using MarketoApiLibrary.Common.Model;
using MarketoApiLibrary.Mis.Request;

namespace MarketoApiLibrary.Asset.SmartLists.Request
{
    public class CloneSmartListRequest:BaseRequest
    {
        public long Id { get; set; }
        public string Name { get; set; }
        public Folder Folder { get; set; }
        public string Description { get; set; }
    }
}