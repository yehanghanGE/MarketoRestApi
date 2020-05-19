using System;
using MarketoApiLibrary.Common.Configuration;
using MarketoApiLibrary.Common.Model;
using MarketoApiLibrary.Mis.Provider;

namespace MarketoApiLibrary.Common.Http.Oauth
{
    public class AuthenticationTokenProvider : IAuthenticationTokenProvider
    {
        private readonly IOAuthTokenCacheService _tokenCacheService;
        private readonly IOAuthTokenRepository _tokenRepository;
        private readonly IApiConfig _oauthConfig;

        private static readonly object LockObject = new object();
        public AuthenticationTokenProvider()
        {
            _tokenRepository = new OAuthTokenRepository();
            _tokenCacheService = new OAuthTokenCacheService();
            _oauthConfig = ConfigurationProvider.LoadConfig();
        }

        public AuthenticationToken GetToken()
        {
            //  Assert.ArgumentNotNull(shop, nameof(shop));

            try
            {
                var parameters = this.GetParameters();

                var token = this._tokenCacheService.GetToken(parameters);
                if (token != null && !this.IsExpired(token))
                    return token;

                lock (LockObject)
                {
                    token = this._tokenCacheService.GetToken(parameters);
                    if (token != null && !this.IsExpired(token))
                        return token;

                    if (token == null)
                        token = this._tokenRepository.GetToken(parameters);
                    else if (this.IsExpired(token))
                        token = this._tokenRepository.GetToken(parameters);

                    this._tokenCacheService.SetToken(parameters, token);

                    return token;
                }
            }
            catch (Exception exception)
            {
                Console.WriteLine(exception.Message, exception);
                //this.logger.Error(exception.Message, exception);
                return null;
            }
        }

        public virtual bool IsExpired(AuthenticationToken token)
        {
            //var margin = this.oauthConfig.RefreshTokenMarginSeconds;
            return token.ExpiresIn < DateTime.UtcNow;
        }

        protected virtual OAuthParameters GetParameters()
        {
            return new OAuthParameters(this._oauthConfig.ClientId, this._oauthConfig.ClientSecret, Constants.OAuth.GrantTypes.ClientCredentials);
        }
    }
}
