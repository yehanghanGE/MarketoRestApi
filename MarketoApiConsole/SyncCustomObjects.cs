using System;
using System.Collections.Generic;
using System.IO;
using System.Net;
using System.Net.Http;
using System.Text;
using Newtonsoft.Json;
using System.Web;

namespace MarketoRestApiLibrary
{
    class SyncCustomObjects
    {
        private String host = "https://529-fgg-715.mktorest.com"; //host of your marketo instance, https://AAA-BBB-CCC.mktorest.com
        private String clientId = "1659dcfa-6624-4b17-a8a9-ccb6c5841f4e"; //clientId from admin > Launchpoint
        private String clientSecret = "cmdYVQHIVGkEwnphZISBsTtuLihMCMOz"; //clientSecret from admin > Launchpoint
        public String name;//name of custom object type
        public List<Dictionary<string, dynamic>> input;//list of Custom Object representations
        public String action;//createOnly, updateOnly, createOrUpdate, defaults to createOrUpdate
        public String dedupeBy;//dedupeFields or idField for object, only valid for updateOnly

        
        //public static void Main(string[] args)
        //{
        //    var upsert = new SyncCustomObjects();
        //    upsert.name = "sitecore_cart_c";
        //    String result = upsert.DescribeCustomObjects();
        //    var jsonFormatted = JToken.Parse(result).ToString(Formatting.Indented);
        //    Console.WriteLine(jsonFormatted);

        //    upsert.action = "createOrUpdate";
        //    upsert.dedupeBy = "dedupeFields";
        //    upsert.name = "sitecore_cart_c";
        //    var prod = new Dictionary<string, dynamic>();
        //    //Our Pet object has two dedupe fields, owner and name
        //    prod.Add("cart_id", "3121137123457");
        //    prod.Add("lead_id", "3121137");
        //    prod.Add("product_id", "123457");
        //    prod.Add("product_name", "prod_a");
        //    prod.Add("product_price", "123.48");
        //    prod.Add("quantity", "1");

        //    var prod1 = new Dictionary<string, dynamic>();
        //    //Our Pet object has two dedupe fields, owner and name
        //    prod1.Add("cart_id", "3121137123458");
        //    prod1.Add("lead_id", "3121137");
        //    prod1.Add("product_id", "123458");
        //    prod1.Add("product_name", "prod_a");
        //    prod1.Add("product_price", "123.48");
        //    prod1.Add("quantity", "1");



        //    upsert.input = new List<Dictionary<string, dynamic>>();
        //    upsert.input.Add(prod);
        //    upsert.input.Add(prod1);

        //    result = upsert.postData();
        //    jsonFormatted = JToken.Parse(result).ToString(Formatting.Indented);
        //    Console.Write(jsonFormatted);
        //}

        public String DescribeCustomObjects()
        {
            var qs = HttpUtility.ParseQueryString(string.Empty);
            qs.Add("access_token", getToken());
            String url = host + "/rest/v1/customobjects/" + name + "/describe.json?" + qs.ToString();
            HttpWebRequest request = (HttpWebRequest)WebRequest.Create(url);
            request.ContentType = "application/json";
            request.Accept = "application/json";
            HttpWebResponse response = (HttpWebResponse)request.GetResponse();
            Stream resStream = response.GetResponseStream();
            StreamReader reader = new StreamReader(resStream);
            return reader.ReadToEnd();
        }
        public String postData()
        {
            //Assemble the URL
            String url = host + "/rest/v1/customobjects/" + name + ".json?access_token=" + getToken();

            var httpClient = new HttpClient();
            var content = new StringContent(bodyBuilder(), Encoding.UTF8, "application/json");
            var response = httpClient.PostAsync(url, content).Result;

            response.EnsureSuccessStatusCode();

            return response.Content.ReadAsStringAsync().Result;


            //HttpWebRequest request = (HttpWebRequest)WebRequest.Create(url);
            //request.Method = "POST";
            //request.ContentType = "application/json";
            //request.Accept = "application/json";
            //StreamWriter wr = new StreamWriter(request.GetRequestStream());
            ////add serialized json body to request stream
            //wr.Write(bodyBuilder());
            //wr.Flush();
            //HttpWebResponse response = (HttpWebResponse)request.GetResponse();
            //Stream resStream = response.GetResponseStream();
            //StreamReader reader = new StreamReader(resStream);
            //return reader.ReadToEnd();
        }
        private String bodyBuilder()
        {
            var parent = new Dictionary<string, dynamic>();
            if (action != null)
            {
                parent.Add("action", action);
            }
            if (dedupeBy != null)
            {
                parent.Add("dedupeBy", dedupeBy);
            }
            parent.Add("input", input);

            return JsonConvert.SerializeObject(parent);
        }

        private String getToken()
        {
            String url = host + "/identity/oauth/token?grant_type=client_credentials&client_id=" + clientId + "&client_secret=" + clientSecret;
            HttpWebRequest request = (HttpWebRequest)WebRequest.Create(url);
            request.ContentType = "application/json";
            HttpWebResponse response = (HttpWebResponse)request.GetResponse();
            Stream resStream = response.GetResponseStream();
            StreamReader reader = new StreamReader(resStream);
            String json = reader.ReadToEnd();
            //Dictionary<String, Object> dict = JavaScriptSerializer.DeserializeObject(reader.ReadToEnd);
            Dictionary<String, String> dict = JsonConvert.DeserializeObject<Dictionary<String, String>>(json);
            return dict["access_token"];
        }
    }
}
