namespace MarketoApiLibrary.Model
{
    public class ApiConfig : IApiConfig
    {
        public string Host { get; set; }
        public string ClientId { get; set; }
        public string ClientSecret { get; set; }
    }
}
