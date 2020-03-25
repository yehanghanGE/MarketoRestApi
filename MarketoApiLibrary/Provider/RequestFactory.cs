using MarketoRestApiLibrary.Request;
using System.Collections.Generic;

namespace MarketoRestApiLibrary.Provider
{
    public class RequestFactory : IRequestFactory
    {
        public RequestFactory()
        {

        }
        //public GetFilesRequest CreateGetFilesRequest(string host, string token)
        //{
        //    Dictionary<string, dynamic> folder = new Dictionary<string, dynamic>();
        //    folder.Add("id", 29514);
        //    folder.Add("type", "Folder");
        //    var getFilesRequest = new GetFilesRequest()
        //    {
        //        Host = host,
        //        Token = token,
        //        //Offset = 10,
        //        //MaxReturn = 3,
        //        Folder = folder
        //    };

        //    return getFilesRequest;
        //}
        public GetFolderByNameRequest CreateGetFolderByNameRequest(string host, string token)
        {
            Dictionary<string, dynamic> root = new Dictionary<string, dynamic>();
            root.Add("id", 17445);
            root.Add("type", "folder");

            var getFolderByNameRequest = new GetFolderByNameRequest()
            {
                Host = host,
                Token = token,
                Name = "LATAM", //required
                //Type = "Folder",//optional
                //WorkSpace = "GL LS - Global Life Sciences",
                Root = null     //optional
            };

            return getFolderByNameRequest;
        }
        public GetFoldersRequest CreateGetFoldersRequest(string host, string token)
        {
            Dictionary<string, dynamic> root = new Dictionary<string, dynamic>();
            root.Add("id", 76383);
            root.Add("type", "folder");

            var getFoldersRequest = new GetFoldersRequest()
            {
                Host = host,
                Token = token,
                Offset = 0,
                MaxDepth = 10,
                MaxReturn = 200,
                Root = root
                //WorkSpace = "GL LS - Global Life Sciences"
            };

            return getFoldersRequest;
        }
        public BaseRequest CreategetActivityTypesResult(string host, string token)
        {
            var request = new BaseRequest()
            {
                Host = host,
                Token = token
            };

            return request;
        }
        public BaseRequest CreateGetSmartListRequest(string host, string token)
        {
            var request = new BaseRequest()
            {
                Host = host,
                Token = token
            };

            return request;
        }
        public LeadsExportRequest CreateGetLeadsExportRequest(string host, string token)
        {
            var filter = new Dictionary<string, dynamic>();
            filter.Add("staticListName", "List Import");

            string outputFormat = "csv";
            string startAtTime = "2017-8-01T23:59:59-00:00";
            string endAt = "2017-8-30T23:59:59-00:00";
            var request = new LeadsExportRequest()
            {
                Host = host,
                Token = token,
                OutputFormat = outputFormat,
                Fields = new string[] { "firstName", "lastName", "id", "sfdcid", "email", "country" },
                Filters = filter
            };

            return request;
        }
        public ActivitiesExportRequest CreateActivitiesExportRequest(string host, string token)
        {
            string outputFormat = "csv";
            string startAtTime = "2017-8-01T23:59:59-00:00";
            string endAt = "2017-8-30T23:59:59-00:00";
            var filter = new Dictionary<string, dynamic>();
            var createdAt = new Dictionary<string, string>();
            createdAt.Add("startAt", startAtTime);
            createdAt.Add("endAt", endAt);
            filter.Add("createdAt", createdAt);
            int[] _activityTypeIds = new int[] { 1, 2, 10, 11, 22, 46 };
            filter.Add("activityTypeIds", _activityTypeIds);

            var request = new ActivitiesExportRequest()
            {
                Host = host,
                Token = token,
                OutputFormat = outputFormat,
                Filters = filter
            };

            return request;
        }
        public CustomObjectsRequest CreateCustomObjectsRequest(string host, string token)
        {
            var prod = new Dictionary<string, dynamic>();
            prod.Add("cart_id", "3121137123457");
            prod.Add("lead_id", "3121137");
            prod.Add("product_id", "123457");
            prod.Add("product_name", "prod_a");
            prod.Add("product_price", "123.48");
            prod.Add("quantity", "1");
            var prod1 = new Dictionary<string, dynamic>();
            prod1.Add("cart_id", "3121137123458");
            prod1.Add("lead_id", "3121137");
            prod1.Add("product_id", "123458");
            prod1.Add("product_name", "prod_a");
            prod1.Add("product_price", "123.48");
            prod1.Add("quantity", "1");
            List<Dictionary<string, dynamic>> input = new List<Dictionary<string, dynamic>>();
            input.Add(prod);
            input.Add(prod1);
            var request = new CustomObjectsRequest()
            {
                Host = host,
                Token = token,
                Name = "sitecore_cart_c",
                Action = "createOrUpdate", //createOnly, updateOnly, createOrUpdate, defaults to createOrUpdate
                DedupeBy = "dedupeFields", //dedupeFields or idField for object, only valid for updateOnly
                Input = input
            };

            return request;
        }
    }
}
