namespace MarketoApiLibrary.Model
{
    public interface IApiConfig
    {
        string ClientId { get; set; }
        string ClientSecret { get; set; }
        string Host { get; set; }
    }
}