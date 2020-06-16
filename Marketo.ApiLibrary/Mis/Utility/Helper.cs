using System.Collections.Generic;
using System.Text;
using Newtonsoft.Json;
using Newtonsoft.Json.Linq;

namespace Marketo.ApiLibrary.Mis.Utility
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

        public static string JsonFormat(string jsonString)
        {
            return JToken.Parse(jsonString).ToString(Formatting.Indented);
        }

        public static string BodyBuilder(string outputFormat, string[] fields, Dictionary<string, dynamic> filter)
        {
            Dictionary<string, dynamic> requestBody = new Dictionary<string, dynamic>();
            requestBody.Add("format", outputFormat);
            requestBody.Add("fields", fields);
            requestBody.Add("filter", filter);

            return JsonConvert.SerializeObject(requestBody);
        }
    }
}
