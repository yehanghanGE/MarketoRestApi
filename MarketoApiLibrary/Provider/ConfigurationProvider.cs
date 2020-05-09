using MarketoApiLibrary.Model;
using System.Configuration;

namespace MarketoApiLibrary.Provider
{
    public static class ConfigurationProvider
    {
        public static ApiConfig LoadConfig()
        {
            Configuration configManager = ConfigurationManager.OpenExeConfiguration(ConfigurationUserLevel.None);
            KeyValueConfigurationCollection confCollection = configManager.AppSettings.Settings;

            ApiConfig apiConfig = new ApiConfig()
            {
                Host = confCollection[Constants.ApiConfigCredentials.Host]?.Value,
                ClientId = confCollection[Constants.ApiConfigCredentials.ClientId]?.Value,
                ClientSecret = confCollection[Constants.ApiConfigCredentials.ClientSecret]?.Value,
                AuthorizeRelativePath = confCollection[Constants.ApiConfigCredentials.AuthorizeRelativePath]?.Value,
                RequestTimeoutSeconds = confCollection[Constants.ApiConfigCredentials.RequestTimeoutSeconds]?.Value
            };

            return apiConfig;

        }
    }
}
