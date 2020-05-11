﻿namespace MarketoApiLibrary
{
    public static class Constants
    {
        public static class OAuth
        {
            public const string Host = "host";
            public const string AuthorizeRelativePath = "authorizeRelativePath";
            public const string ClientId = "clientId";
            public const string ClientSecret = "clientSecret";
            public const string RequestTimeoutSeconds = "requestTimeoutSeconds";
            public const string RestRelativePath = "restRelativePath";
            public const string GrantType = "grant_type";

            public static class GrantTypes
            {
                public const string ClientCredentials = "client_credentials";
            }
        }

        public static class UrlSegments
        {
            public const string Asset = "asset";
            public const string Version = "v1";
            public const string SmartLists = "smartLists.json";
        }

        public static class QueryParameters
        {
            public static class Asset
            {
                public  static class SmartList
                {
                    public static class Keys
                    {
                        public const string Folder = "folder";
                        public const string Offset = "offset";
                        public const string MaxReturn = "maxReturn";
                        public const string EarliestUpdatedAt = "earliestUpdatedAt";
                        public const string LatestUpdatedAt = "latestUpdatedAt";
                    }

                    public static class Values
                    {
                        
                    }
                }
            }
           
        }
    }
   
}
