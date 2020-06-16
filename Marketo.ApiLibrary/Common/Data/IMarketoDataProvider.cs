using Marketo.ApiLibrary.Common.Http.ValueObjects;
using Marketo.ApiLibrary.Common.Logging;
using Marketo.ApiLibrary.Common.Model;

namespace Marketo.ApiLibrary.Common.Data
{
    public interface IMarketoDataProvider
    {
        T ExecuteRequest<T>(HttpRequest request, ILoggingService<ILogInstance> logger) where T : ApiModel;
    }
}