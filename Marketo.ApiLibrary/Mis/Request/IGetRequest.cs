namespace Marketo.ApiLibrary.Mis.Request
{
    public interface IGetRequest
    {
        string Url { get; set; }

        T Run<T>();
    }
}