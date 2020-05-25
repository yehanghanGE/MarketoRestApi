﻿namespace MarketoApiLibrary
{
    public static class Constants
    {
        public static class OAuth
        {
            public const string Host = "host";
            public const string AuthorizeRelativePath = "authorizeRelativePath";
            public const string ClientId = "client_id";
            public const string ClientSecret = "client_secret";
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
            public const string SmartList = "smartList";
            public const string ByName = "byName.json";
            public const string Delete = "delete.json";
            public const string Clone = "clone.json";
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
                        public const string IncludeRules = "includeRules";
                        public const string SmartListName = "name";
                    }

                    public static class Values
                    {
                        
                    }
                }
            }
           
        }
    }
   
}
