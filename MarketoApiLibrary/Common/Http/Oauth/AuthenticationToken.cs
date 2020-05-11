using System;

namespace MarketoApiLibrary.Common.Http.Oauth
{
    public class AuthenticationToken
    {
        /// <summary>
        /// OAuth 2.0 token
        /// </summary>
        public string Token { get; }
        /// <summary>
        /// OAuth 2.0 token type
        /// </summary>
        public string TokenType { get; }
        /// <summary>
        /// OAuth 2.0 refresh token value
        /// </summary>
        public string Scope { get; }
        /// <summary>
        ///  UTC expiration date of the token
        /// </summary>
        public DateTime ExpiresIn { get; }
        public AuthenticationToken(string token, string tokenType, int expiresIn, string scope)
        {
            this.Token = token;
            this.TokenType = tokenType;
            this.ExpiresIn = DateTime.UtcNow.AddSeconds(expiresIn);
            this.Scope = scope;
        }
    }
}