using MarketoApiLibrary.Common.Http.ValueObjects;
using MarketoApiLibrary.Common.Logging;
using MarketoApiLibrary.Common.Model;

namespace MarketoApiLibrary.Common.Data
{
    public interface IMarketoDataProvider
    {
        T ExecuteRequest<T>(HttpRequest request, ILoggingService<ILogInstance> logger) where T : ApiModel;
    }
}