using System;
using System.Collections.Generic;
using System.Text;
using Marketo.ApiLibrary.Lead.Leads;
using Newtonsoft.Json.Linq;

namespace Marketo.Console
{
    public class LeadsExample
    {
        public static void Main(string[] args)
        {
            try
            {
                var result = Leads.DescibeLead();

                System.Console.WriteLine(JToken.FromObject(result).ToString());
                System.Console.ReadKey();
            }
            catch (Exception ex)
            {
                System.Console.WriteLine(ex.ToString());
            }
        }
    }
}
