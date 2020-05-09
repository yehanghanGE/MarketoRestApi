namespace MarketoApiLibrary.Model
{
    public interface IApiConfig
    {
        string ClientId { get; set; }
        string ClientSecret { get; set; }
        string Host { get; set; } 
        string AuthorizeRelativePath { get; set; }
        string RequestTimeoutSeconds { get; set; }
    }
}