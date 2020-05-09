using System;
using System.Collections.Generic;

namespace MarketoApiLibrary.Http.Oauth
{
    public class OAuthParameters
    {
        public string ClientId { get; }

        public string ClientSecret { get; }

        public string GrantType { get; }

        public Dictionary<string, string> AdditionalParameters { get; set; }

        public OAuthParameters(string clientId, string clientSecret, string grantType, Dictionary<string, string> additionalParameters = null)
        {
            this.ClientId = clientId;
            this.ClientSecret = clientSecret;
            this.GrantType = grantType;
            this.AdditionalParameters = additionalParameters ?? new Dictionary<string, string>();
        }

        public override bool Equals(object obj)
        {
            var parameters = obj as OAuthParameters;
            if (parameters == null)
                return false;

            return this.ClientId == parameters.ClientId
                   && this.ClientSecret == parameters.ClientSecret
                   && this.GrantType == parameters.GrantType
                   && CheckAdditionalParametersEquality(this.AdditionalParameters, parameters.AdditionalParameters);
        }

        public override int GetHashCode()
        {
            return string.Join(string.Empty, this.ClientId, this.ClientSecret, this.GrantType).GetHashCode();
        }

        private static bool CheckAdditionalParametersEquality(Dictionary<string, string> thisDict, Dictionary<string, string> incomingDict)
        {
            if (thisDict.Count != incomingDict.Count)
                return false;

            var thisKeys = thisDict.Keys;
            foreach (var key in thisKeys)
            {
                string value;
                var hasValue = incomingDict.TryGetValue(key, out value);
                if (!(hasValue && string.Equals(thisDict[key], value, StringComparison.OrdinalIgnoreCase)))
                    return false;
            }

            return true;
        }
    }
}
