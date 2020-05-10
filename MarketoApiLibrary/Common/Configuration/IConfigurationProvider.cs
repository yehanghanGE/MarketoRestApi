using MarketoApiLibrary.Common.Model;

namespace MarketoApiLibrary.Common.Configuration
{
    public interface IConfigurationProvider
    {
        ApiConfig LoadConfig();
    }
}