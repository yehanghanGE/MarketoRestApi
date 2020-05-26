using System;
using MarketoApiLibrary.Asset.SmartLists;
using Newtonsoft.Json.Linq;

namespace MarketoApiConsole
{
    public class SmartListExample
    {
        public static void Main(string[] args)
        {
            try
            {
                //var result = SmartList.GetSmartList();
                //var result = SmartList.GetSmartListById(1266, false);
                //var result = SmartList.GetSmartListByName("SL SFDC Contact Sync");
                var result = SmartList.DeleteSmartList(1915);
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
