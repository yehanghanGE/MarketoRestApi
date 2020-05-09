namespace MarketoApiLibrary.Oauth
{
    /// <summary>
    /// Provides methods for working with cached OAuth tokens
    /// </summary>
    public interface IOAuthTokenCacheService
    {
        /// <summary>
        /// Gets token from cache
        /// </summary>
        /// <param name="parameters"></param>
        /// <returns></returns>
        AuthenticationToken GetToken(OAuthParameters parameters);
        /// <summary>
        /// Sets token in cache
        /// </summary>
        /// <param name="parameters"></param>
        /// <param name="token"></param>
        void SetToken(OAuthParameters parameters, AuthenticationToken token);
    }
}