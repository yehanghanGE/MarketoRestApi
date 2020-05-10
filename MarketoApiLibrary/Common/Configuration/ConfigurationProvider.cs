using System.Configuration;
using MarketoApiLibrary.Common.Model;

namespace MarketoApiLibrary.Common.Configuration
{
    public static class ConfigurationProvider
    {
        public static ApiConfig LoadConfig()
        {
            System.Configuration.Configuration configManager = ConfigurationManager.OpenExeConfiguration(ConfigurationUserLevel.None);
            KeyValueConfigurationCollection confCollection = configManager.AppSettings.Settings;

            ApiConfig apiConfig = new ApiConfig()
            {
                Host = confCollection[Constants.OAuth.Host]?.Value,
                ClientId = confCollection[Constants.OAuth.ClientId]?.Value,
                ClientSecret = confCollection[Constants.OAuth.ClientSecret]?.Value,
                AuthorizeRelativePath = confCollection[Constants.OAuth.AuthorizeRelativePath]?.Value,
                RestRelativePath = confCollection[Constants.OAuth.RestRelativePath]?.Value,
                RequestTimeoutSeconds = confCollection[Constants.OAuth.RequestTimeoutSeconds]?.Value
            };

            return apiConfig;
        }
    }

    public class ConfigurationProvider2 : IConfigurationProvider
    {
        public ApiConfig LoadConfig()
        {
            System.Configuration.Configuration configManager = ConfigurationManager.OpenExeConfiguration(ConfigurationUserLevel.None);
            KeyValueConfigurationCollection confCollection = configManager.AppSettings.Settings;

            ApiConfig apiConfig = new ApiConfig()
            {
                Host = confCollection[Constants.OAuth.Host]?.Value,
                ClientId = confCollection[Constants.OAuth.ClientId]?.Value,
                ClientSecret = confCollection[Constants.OAuth.ClientSecret]?.Value,
                AuthorizeRelativePath = confCollection[Constants.OAuth.AuthorizeRelativePath]?.Value,
                RestRelativePath = confCollection[Constants.OAuth.RestRelativePath]?.Value,
                RequestTimeoutSeconds = confCollection[Constants.OAuth.RequestTimeoutSeconds]?.Value
            };

            return apiConfig;
        }
    }
}
