namespace Marketo.ApiLibrary.Common.Http.Oauth
{
    public interface IAuthenticationTokenProvider
    {
        AuthenticationToken GetToken();
        bool IsExpired(AuthenticationToken token);
    }
}