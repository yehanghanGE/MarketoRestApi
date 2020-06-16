using System.Security.AccessControl;
using Marketo.ApiLibrary.Common.Model;
using Marketo.ApiLibrary.Mis.Request;

namespace Marketo.ApiLibrary.Asset.SmartLists.Request
{
    public class CloneSmartListRequest:BaseRequest
    {
        public long Id { get; set; }
        public string Name { get; set; }
        public Folder Folder { get; set; }
        public string Description { get; set; }
    }
}