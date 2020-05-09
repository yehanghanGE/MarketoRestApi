namespace MarketoApiLibrary.Oauth
{
    /// <summary>
    /// Provides methods for working with OAuth tokens that are received from Marketo
    /// </summary>
    public interface IOAuthTokenRepository
    {
        /// <summary>
        /// Get OAuth token according to specified parameters
        /// </summary>
        /// <param name="parameters"></param>
        /// <param name="refreshToken"></param>
        /// <returns></returns>
        AuthenticationToken GetToken(OAuthParameters parameters, string refreshToken = null);
    }
}