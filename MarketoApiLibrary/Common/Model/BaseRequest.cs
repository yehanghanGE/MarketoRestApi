using MarketoApiLibrary.Common.Http.Oauth;

namespace MarketoApiLibrary.Common.Model
{
    public class BaseRequest
    {
        public string Token { get; set; }
        public string Host { get; set; }

        public AuthenticationToken AuthenticationToken { get; set; }
    }
}