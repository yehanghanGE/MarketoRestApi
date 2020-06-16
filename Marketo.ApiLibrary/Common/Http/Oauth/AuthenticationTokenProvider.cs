using Marketo.ApiLibrary.Common.Model;
using System;
using Marketo.ApiLibrary.Common.Configuration;
using Marketo.ApiLibrary.Common.Logging;

namespace Marketo.ApiLibrary.Common.Http.Oauth
{
    public class AuthenticationTokenProvider : IAuthenticationTokenProvider
    {
        private readonly IOAuthTokenCacheService _tokenCacheService;
        private readonly IOAuthTokenRepository _tokenRepository;
        private readonly IConfigurationProvider _configurationProvider;
        private readonly IApiConfig _oauthConfig;
        private readonly ILoggingService<CommerceLog> _logger;

        private static readonly object LockObject = new object();
        public AuthenticationTokenProvider(IOAuthTokenCacheService tokenCacheService, IOAuthTokenRepository tokenRepository, IConfigurationProvider configurationProvider, ILoggingService<CommerceLog> logger)
        {
            _tokenCacheService = tokenCacheService;
            _tokenRepository = tokenRepository;
            _configurationProvider = configurationProvider;
            _logger = logger;

            _oauthConfig = _configurationProvider.LoadConfig();
        }

        public AuthenticationToken GetToken()
        {
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
                this._logger.Error(exception.Message, exception);
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
