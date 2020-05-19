using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MarketoApiLibrary.Asset.SmartLists;
using MarketoApiLibrary.Common.Http.Oauth;
using Newtonsoft.Json.Linq;

namespace MarketoApiConsole
{
    public class SmartListExample
    {
        public static void Main(string[] args)
        {
            try
            {

                var result = SmartList.GetSmartList();

                Console.WriteLine(JToken.FromObject(result).ToString());
                Console.ReadKey();
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.ToString());
            }
        }
    }
}
