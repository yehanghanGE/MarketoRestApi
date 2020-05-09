using System.Collections.Concurrent;

namespace MarketoApiLibrary.Oauth
{
    public class OAuthTokenCacheService : IOAuthTokenCacheService
    {
        private static readonly ConcurrentDictionary<OAuthParameters, AuthenticationToken> Cache = new ConcurrentDictionary<OAuthParameters, AuthenticationToken>();

        public AuthenticationToken GetToken(OAuthParameters parameters)
        {
            //Assert.ArgumentNotNull(parameters, nameof(parameters));

            AuthenticationToken value;
            var token = !OAuthTokenCacheService.Cache.TryGetValue(parameters, out value) ? null : value;
            return token;
        }

        public void SetToken(OAuthParameters parameters, AuthenticationToken token)
        {
            //Assert.ArgumentNotNull(parameters, nameof(parameters));
            //Assert.ArgumentNotNull(token, nameof(token));

            OAuthTokenCacheService.Cache.AddOrUpdate(parameters, token, (key, existingToken) => token);
        }
    }
}
