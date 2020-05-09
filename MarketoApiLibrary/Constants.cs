namespace MarketoApiLibrary
{
    public static class Constants
    {
        public static class ApiConfigCredentials
        {
            public const string Host = "host";
            public const string AuthorizeRelativePath = "authorizeRelativePath";
            public const string ClientId = "clientId";
            public const string ClientSecret = "clientSecret";
            public const string RequestTimeoutSeconds = "requestTimeoutSeconds";
        }

        public static class OAuth
        {
            public const string ClientId = "client_id";
            public const string ClientSecret = "client_secret";
            public const string GrantType = "grant_type";
            public const string RefreshToken = "refresh_token";

            public static class GrantTypes
            {
                public const string ClientCredentials = "client_credentials";
            }
        }
    }
   
}
