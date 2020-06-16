using System.Collections.Concurrent;

namespace Marketo.ApiLibrary.Common.Http.Oauth
{
    public class OAuthTokenCacheService : IOAuthTokenCacheService
    {
        private static readonly ConcurrentDictionary<OAuthParameters, AuthenticationToken> Cache = new ConcurrentDictionary<OAuthParameters, AuthenticationToken>();

        public AuthenticationToken GetToken(OAuthParameters parameters)
        {
            AuthenticationToken value;
            var token = !Cache.TryGetValue(parameters, out value) ? null : value;
            return token;
        }

        public void SetToken(OAuthParameters parameters, AuthenticationToken token)
        {
            Cache.AddOrUpdate(parameters, token, (key, existingToken) => token);
        }
    }
}
