using System;
using System.Collections.Generic;
using System.Configuration;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MarketoRestApiLibrary.Provider
{
    public static class ConfigurationProvider
    {
        public static ApiConfig LoadConfig()
        {
            Configuration configManager = ConfigurationManager.OpenExeConfiguration(ConfigurationUserLevel.None);
            KeyValueConfigurationCollection confCollection = configManager.AppSettings.Settings;

            var apiConfig = new ApiConfig()
            {
                Host = confCollection[ApiConfigCredentials.Host]?.Value,
                ClientId = confCollection[ApiConfigCredentials.ClientId]?.Value,
                ClientSecret = confCollection[ApiConfigCredentials.ClientSecret]?.Value
            };

            return apiConfig;

        }
    }
}
