namespace MarketoApiLibrary.Request
{
    public class Folder
    {
        //Folder {
            //        id(integer) : Id of the folder,
            //            type (string): Type of folder = ['Folder', 'Program']
            //    }
        public int Id { get; set; }
        public string Type { get; set; }
    }
}