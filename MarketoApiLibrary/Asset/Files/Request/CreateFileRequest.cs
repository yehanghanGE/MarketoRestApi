using MarketoApiLibrary.Common.Model;
using MarketoApiLibrary.Mis.Request;

namespace MarketoApiLibrary.Asset.Files.Request
{
    public class CreateFileRequest : BaseRequest
    {
    //    CreateFileRequest {
    //        description(string, optional) : Description of the asset,
    //            file (string): Multipart file.Content of the file. ,
    //        folder (Folder): JSON representation of parent folder, with members 'id', and 'type' which may be 'Folder' or 'Program' ,
    //        insertOnly (boolean, optional): Whether the calls hould fail if there is already an existing file with the same name,
    //            name (string): Name of the File
    //    }
    //    

    public string Description { get; set; } = "default description";
        public string FilePath { get; set; }
        public Folder Folder { get; set; }
        public bool InsertOnly { get; set; } = true;
        public string Name { get; set; }
    }
}
