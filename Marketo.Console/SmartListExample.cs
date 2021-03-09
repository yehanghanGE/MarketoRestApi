using System;
using Marketo.ApiLibrary.Asset.SmartLists;
using Newtonsoft.Json.Linq;

namespace Marketo.Console
{
    public class SmartListExample
    {
        public static void Main(string[] args)
        {
            try
            {
                var result = SmartList.GetSmartList();
                //var result = SmartList.GetSmartListById(1266, false);
                //var result = SmartList.GetSmartListByName("SL SFDC Contact Sync");
                //var result = SmartList.CloneSmartList(1266, "cloneTest", 1001, "Program");

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
