using MarketoApiLibrary.Model;

namespace MarketoApiLibrary.Response
{
    public interface IFileResponse
    {
        string CreatedAt { get; set; }
        string Description { get; set; }
        int Id { get; set; }
        FileFolder Folder { get; set; }
        string MimeType { get; set; }
        string Name { get; set; }
        int Size { get; set; }
        string UpdatedAt { get; set; }
        string Url { get; set; }
    }
}