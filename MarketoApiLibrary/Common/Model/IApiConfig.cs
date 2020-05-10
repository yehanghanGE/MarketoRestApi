namespace MarketoApiLibrary.Common.Model
{
    public interface IApiConfig
    {
        string ClientId { get; set; }
        string ClientSecret { get; set; }
        string Host { get; set; } 
        string AuthorizeRelativePath { get; set; }
        string RestRelativePath { get; set; }
        string RequestTimeoutSeconds { get; set; }
    }
}