namespace MarketoApiLibrary.Model
{
    public class ApiConfig : IApiConfig
    {
        public string Host { get; set; }
        public string AuthorizeRelativePath { get; set; }
        public string RequestTimeoutSeconds { get; set; }
        public string ClientId { get; set; }
        public string ClientSecret { get; set; }
    }
}
