using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Net;
using System.Text;
using System.Threading.Tasks;

namespace MarketoRestApiLibrary.Provider
{
    public static class TokenProvider
    {
        public static string GetToken(string host, string clientId, string clientSecret)
        {
            string url = host + "/identity/oauth/token?grant_type=client_credentials&client_id=" + clientId + "&client_secret=" + clientSecret;
            HttpWebRequest request = (HttpWebRequest)WebRequest.Create(url);
            request.ContentType = "application/json";
            HttpWebResponse response = (HttpWebResponse)request.GetResponse();
            Stream resStream = response.GetResponseStream();
            StreamReader reader = new StreamReader(resStream);
            String json = reader.ReadToEnd();
            Dictionary<String, String> dict = JsonConvert.DeserializeObject<Dictionary<String, String>>(json);
            return dict["access_token"];
        }
    }
}
