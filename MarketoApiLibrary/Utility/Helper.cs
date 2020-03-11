using Newtonsoft.Json;
using Newtonsoft.Json.Linq;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MarketoRestApiLibrary
{
    public static class Helper
    {
        public static string CsvString(string[] args)
        {
            StringBuilder sb = new StringBuilder();
            int i = 1;
            foreach (string s in args)
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

        public static string JSONFormat(string jsonString)
        {
            return JToken.Parse(jsonString).ToString(Formatting.Indented);
        }

        public static string BodyBuilder(string outputFormat, string[] fields, Dictionary<string, dynamic> filter)
        {
            var requestBody = new Dictionary<string, dynamic>();
            requestBody.Add("format", outputFormat);
            requestBody.Add("fields", fields);
            requestBody.Add("filter", filter);

            return JsonConvert.SerializeObject(requestBody);
        }
    }
}
