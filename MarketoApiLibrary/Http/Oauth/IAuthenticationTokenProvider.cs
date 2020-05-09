namespace MarketoApiLibrary.Http.Oauth
{
    public interface IAuthenticationTokenProvider
    {
        AuthenticationToken GetToken();
        bool IsExpired(AuthenticationToken token);
    }
}