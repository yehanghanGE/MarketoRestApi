using Marketo.ApiLibrary.Common.Model;

namespace Marketo.ApiLibrary.Common.Configuration
{
    public interface IConfigurationProvider
    {
        ApiConfig LoadConfig();
    }
}