using System;
using System.Collections.Generic;
using System.IO;
using System.Net;
using System.Text;
using System.Web;
using Newtonsoft.Json;
using Newtonsoft.Json.Linq;

namespace MarketoRestApiLibrary
{
    class SendCartInfo
    {
        private String host = "https://529-fgg-715.mktorest.com"; //host of your marketo instance, https://AAA-BBB-CCC.mktorest.com
        private String clientId = "1659dcfa-6624-4b17-a8a9-ccb6c5841f4e"; //clientId from admin > Launchpoint
        private String clientSecret = "cmdYVQHIVGkEwnphZISBsTtuLihMCMOz"; //clientSecret from admin > Launchpoint
        //private String host = "https://005-SHS-767.mktorest.com";
        //private String clientId = "effd85c2-28ab-4156-96ee-1260694e8db6"; //clientId from admin > Launchpoint
        //private String clientSecret = "3zf2kUuzQ5MPEo6LUfacgCX9SH8D8mkE";
        public String name;//custom object type
        public String[] names;//optional list of custom object names to return
        public List<Dictionary<string, dynamic>> input;//list of Custom Object representations
        public String action;//createOnly, updateOnly, createOrUpdate, defaults to createOrUpdate
        public String dedupeBy;//dedupeFields or idField for object, only valid for updateOnly
        public String filterType;
        public String[] filterValues;
        public int batchSize;
        public String[] fields;
        public String nextPageToken;
        public String activityTypeId = "100005";
        public String lookupField;
        public String sinceDatetime;
        public int[] activityTypeIds;
        public int listId;
        public String leadIds;

        //static void Main(string[] args)
        //{
        //    SendCartInfo leads = new SendCartInfo();
        //    leads.action = "createOrUpdate";
        //    leads.lookupField = "email";
        //    var lead  = new Dictionary<string, dynamic>();
        //    lead.Add("email","test_marketo@ge.com");
        //    lead.Add("firstname","han");
        //    lead.Add("postalCode","123456");
        //    leads.input = new List<Dictionary<string, dynamic>>();
        //    leads.input.Add(lead);
        //    var result = leads.createLead();
        //    var jsonFormatted = JToken.Parse(result).ToString(Formatting.Indented);
        //    Console.WriteLine("Add or Update a lead.");
        //    Console.WriteLine(jsonFormatted);
        //    leads = new SendCartInfo();
        //    leads.filterType = "email";
        //    leads.filterValues = new String[] { "test_marketo@ge.com" };
        //    leads.fields = new String[] {"id"};
        //    result = leads.getLeadsByFilterType();
        //    jsonFormatted = JToken.Parse(result).ToString(Formatting.Indented);
        //    Console.WriteLine("Get lead id using Email.");
        //    Console.WriteLine(jsonFormatted);
        //    var response = JsonConvert.DeserializeObject<MarketoResponse>(result);
        //    object id = new object();
        //    var time = DateTime.UtcNow;
        //    if (response.Success&response.Result.Count>0)
        //    {
        //        id = response.Result[0]["id"];
        //        leads = new SendCartInfo();
        //        var customactivities = new Dictionary<string, dynamic>();
        //        customactivities.Add("leadId", id);
        //        customactivities.Add("activityDate", time);
        //        customactivities.Add("activityTypeId", leads.activityTypeId);
        //        customactivities.Add("primaryAttributeValue", leads.activityTypeId);
        //        leads.input = new List<Dictionary<string, dynamic>>();
        //        leads.input.Add(customactivities);
        //        result = leads.addCustomActivities();
        //        jsonFormatted = JToken.Parse(result).ToString(Formatting.Indented);
        //        Console.WriteLine("Add a new Custom Activity");
        //        Console.WriteLine(jsonFormatted);
        //    }

            
        //    leads = new SendCartInfo();
        //    leads.sinceDatetime = time.ToString("s");
        //    result = leads.getPageToken();
        //    var nextPageTokenResponse = JsonConvert.DeserializeObject<PageTokenResponse>(result);
        //    leads.nextPageToken = nextPageTokenResponse.NextPageToken;
        //    leads.activityTypeIds = new int[] { 100005 };
        //    leads.leadIds = id.ToString();
        //    result = leads.getLeadActivities();
        //    jsonFormatted = JToken.Parse(result).ToString(Formatting.Indented);
        //    var customActiviesResponse = JsonConvert.DeserializeObject<CustomActiviesResponse>(result);
        //    Console.WriteLine("Get custom activities.");
        //    Console.WriteLine(jsonFormatted);
        //    var moreResult = customActiviesResponse.MoreResult;
        //    //while (moreResult)
        //    //{
        //    //    leads = new SendCartInfo();
        //    //    leads.sinceDatetime = "2017-07-20T00:00:00-00:00";
        //    //    leads.nextPageToken = customActiviesResponse.NextPageToken;
        //    //    leads.activityTypeIds = new int[] { 100005 };
        //    //    result = leads.getLeadActivities();
        //    //    jsonFormatted = JToken.Parse(result).ToString(Formatting.Indented);
        //    //    Console.WriteLine(jsonFormatted);
        //    //    customActiviesResponse = JsonConvert.DeserializeObject<CustomActiviesResponse>(result);
        //    //    moreResult = customActiviesResponse.MoreResult;
        //    //}

        //    while (true)
        //    {
                
        //    }
           
        //}

       
        
        public String getActivityType()
        {
            String url = host + "/rest/v1/activities/types.json?access_token=" + getToken();
            HttpWebRequest request = (HttpWebRequest)WebRequest.Create(url);
            request.ContentType = "application/json";
            request.Accept = "application/json";
            HttpWebResponse response = (HttpWebResponse)request.GetResponse();
            Stream resStream = response.GetResponseStream();
            StreamReader reader = new StreamReader(resStream);
            return reader.ReadToEnd();
        }
        public String getLeadsByFilterType()
        {
            StringBuilder url = new StringBuilder(host + "/rest/v1/leads.json?access_token=" + getToken() + "&filterType=" + filterType + "&filterValues=" + csvString(filterValues));
            if (fields != null)
            {
                url.Append("&fields=" + csvString(fields));
            }
            if (batchSize > 0 && batchSize < 300)
            {
                url.Append("&batchSize=" + batchSize);
            }
            if (nextPageToken != null)
            {
                url.Append("&nextPageToken=" + nextPageToken);
            }
            HttpWebRequest request = (HttpWebRequest)WebRequest.Create(url.ToString());
            request.ContentType = "application/json";
            request.Accept = "application/json";
            HttpWebResponse response = (HttpWebResponse)request.GetResponse();
            Stream resStream = response.GetResponseStream();
            
            StreamReader reader = new StreamReader(resStream);
            return reader.ReadToEnd();
        }
        public String addCustomActivities()
        {
            //Assemble the URL
            String url = host + "/rest/v1/activities/external.json?access_token=" + getToken();
            HttpWebRequest request = (HttpWebRequest)WebRequest.Create(url);
            request.Method = "POST";
            request.ContentType = "application/json";
            request.Accept = "application/json";
            StreamWriter wr = new StreamWriter(request.GetRequestStream());
            //add serialized json body to request stream
            wr.Write(bodyBuilder());
            wr.Flush();
            HttpWebResponse response = (HttpWebResponse)request.GetResponse();
            Stream resStream = response.GetResponseStream();
            StreamReader reader = new StreamReader(resStream);
            return reader.ReadToEnd();
        }

        public String createLead()
        {
            //Assemble the URL
            String url = host + "/rest/v1/leads.json?access_token=" + getToken();
            HttpWebRequest request = (HttpWebRequest)WebRequest.Create(url);
            request.Method = "POST";
            request.ContentType = "application/json";
            request.Accept = "application/json";
            StreamWriter wr = new StreamWriter(request.GetRequestStream());
            //add serialized json body to request stream
            wr.Write(bodyBuilder());
            wr.Flush();
            HttpWebResponse response = (HttpWebResponse)request.GetResponse();
            Stream resStream = response.GetResponseStream();
            StreamReader reader = new StreamReader(resStream);
            return reader.ReadToEnd();
        }

        public String getPageToken()
        {
            String url = host + "/rest/v1/activities/pagingtoken.json?access_token=" + getToken() + "&sinceDatetime=" + sinceDatetime;
            HttpWebRequest request = (HttpWebRequest)WebRequest.Create(url);
            request.ContentType = "application/json";
            request.Accept = "application/json";
            HttpWebResponse response = (HttpWebResponse)request.GetResponse();
            Stream resStream = response.GetResponseStream();
            StreamReader reader = new StreamReader(resStream);
            return reader.ReadToEnd();
        }

        public String getLeadActivities()
        {
            String url = host + "/rest/v1/activities.json?access_token=" + getToken() + "&activityTypeIds=" + csvString(activityTypeIds)
                         + "&nextPageToken=" + nextPageToken;
            if (batchSize > 0 && batchSize < 300)
            {
                url += "&batchSize=" + batchSize;
            }
            if (listId > 0)
            {
                url += "&listId=" + listId;
            }
            if (!String.IsNullOrEmpty(leadIds))
            {
                url += "&leadIds=" + leadIds;
            }
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
        private String csvString(String[] args)
        {
            StringBuilder sb = new StringBuilder();
            int i = 1;
            foreach (String s in args)
            {
                if (i < args.Length)
                {
                    sb.Append(s + ",");
                }
                else
                {
                    sb.Append(s);
                }
                i++;
            }
            return sb.ToString();

        }
        private String csvString(int[] args)
        {
            StringBuilder sb = new StringBuilder();
            int i = 1;
            foreach (int s in args)
            {
                if (i < args.Length)
                {
                    sb.Append(s + ",");
                }
                else
                {
                    sb.Append(s);
                }
                i++;
            }
            return sb.ToString();
        }
    }

    public class MarketoResponse
    {
        public string RequestId { get; set; }

        public List<Dictionary<string, object>> Result { get; set; }

        public List<Dictionary<string, object>> Errors { get; set; }

        public bool Success { get; set; }
    }

    public class PageTokenResponse
    {
        public string RequestId { get; set; }

        public string NextPageToken { get; set; }

        public bool Success { get; set; }
    }

    public class CustomActiviesResponse
    {
        public string RequestId { get; set; }

        public string NextPageToken { get; set; }

        public bool Success { get; set; }

        public bool MoreResult { get; set; }
    }


}
