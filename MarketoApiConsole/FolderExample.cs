using MarketoApiLibrary.Asset.Folders;
using Newtonsoft.Json.Linq;
using System;

namespace MarketoApiConsole
{
    public class FolderExample
    {
        public static void Main(string[] args)
        {
            try
            {
                //var result = Folders.GetFolders(419, "Folder");
                //var result = Folders.GetFolderByName("api_test");
                //var result = SmartList.GetSmartListById(1266, false);
                //var result = SmartList.GetSmartListByName("SL SFDC Contact Sync");
                //var result = SmartList.CloneSmartList(1266, "cloneTest", 1001, "Program");
                var result = Folders.GetFolderById(54, "Folder");

                //var result = SmartList.DeleteSmartList(1917);

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
