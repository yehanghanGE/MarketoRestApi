using Marketo.ApiLibrary.Common.Http.Oauth;

namespace Marketo.ApiLibrary.Common.Model
{
    public class BaseRequest
    {
        public string Token { get; set; }
        public string Host { get; set; }

        public AuthenticationToken AuthenticationToken { get; set; }
    }
}