using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MarketoRestApiLibrary
{
    public static class Helper
    {
        public static string CsvString(String[] args)
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
    }
}
