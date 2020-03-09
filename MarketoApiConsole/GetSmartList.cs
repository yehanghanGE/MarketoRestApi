using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Runtime.InteropServices;
using System.Text;
using System.Threading.Tasks;
using Newtonsoft.Json;
using Newtonsoft.Json.Linq;

namespace MarketoRestApiLibrary
{
    class GetSmartList
    {
        private String host         = "https://529-fgg-715.mktorest.com"; //host of your marketo instance, https://AAA-BBB-CCC.mktorest.com
        private String clientId     = "1659dcfa-6624-4b17-a8a9-ccb6c5841f4e"; //clientId from admin > Launchpoint
        private String clientSecret = "cmdYVQHIVGkEwnphZISBsTtuLihMCMOz"; //clientSecret from admin > Launchpoint

        //public static void Main(string[] args)
        //{
        //    GetSmartList smartList = new GetSmartList();
        //    string token = smartList.getToken();
        //    string result = smartList.GetData(token);

        //    System.IO.File.WriteAllText(@"D:\staticlist.json", result);
        //    Console.WriteLine("==========================Done!===============================");
        //    Console.ReadKey();

        //}

        public String GetData(string token)
        {
            String url = host + "/rest/asset/v1/staticLists.json?access_token=" + getToken();
            HttpWebRequest request = (HttpWebRequest)WebRequest.Create(url);
            request.ContentType = "application/json";
            request.Accept = "application/json";
            HttpWebResponse response = (HttpWebResponse)request.GetResponse();
            Stream resStream = response.GetResponseStream();
            StreamReader reader = new StreamReader(resStream);
            return reader.ReadToEnd();
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
