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
                Host = confCollection[ApiConfigCredentials.Host]?.Value,
                ClientId = confCollection[ApiConfigCredentials.ClientId]?.Value,
                ClientSecret = confCollection[ApiConfigCredentials.ClientSecret]?.Value
            };

            return apiConfig;

        }
    }
}
