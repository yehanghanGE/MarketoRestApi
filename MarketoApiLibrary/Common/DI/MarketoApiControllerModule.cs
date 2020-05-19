using MarketoApiLibrary.Asset.SmartLists;
using MarketoApiLibrary.Asset.SmartLists.Request;
using MarketoApiLibrary.Asset.SmartLists.RequestProcessor;
using MarketoApiLibrary.Asset.SmartLists.RequestProvider;
using MarketoApiLibrary.Common.Configuration;
using MarketoApiLibrary.Common.Data;
using MarketoApiLibrary.Common.Http.Services;
using MarketoApiLibrary.Common.Logging;
using MarketoApiLibrary.Common.Services;

namespace MarketoApiLibrary.Common.DI
{
    public class MarketoApiControllerModule : IMarketoApiModule
    {
        public void Initialize(IMarketoApiContainer container)
        {
            container.RegisterType<ISmartListController, SmartListController>(RegistrationLifetime.InstancePerThread);
            container.RegisterType<GetSmartListsProcessor>(RegistrationLifetime.InstancePerThread);
            container.RegisterType<IEntityMapperService,EntityMapperService>(RegistrationLifetime.InstancePerThread);
            container.RegisterType<IApiModelFactory, ApiModelFactory>(RegistrationLifetime.InstancePerThread);
            container.RegisterType<IMarketoDataProvider, MarketoDataProvider>(RegistrationLifetime.InstancePerThread);
            container.RegisterType<IHttpRequestProvider<GetSmartListsRequest>, GetSmartListsRequestProvider>(RegistrationLifetime.InstancePerThread);
            container.RegisterType<IConfigurationProvider, ConfigurationProvider2>(RegistrationLifetime.InstancePerThread);
            container.RegisterType<ILoggingService<CommerceLog>, CommerceLogService>(RegistrationLifetime.InstancePerThread);
            container.RegisterType<ILoggingService<SynchronizationLog>, SynchronizationLogService>(RegistrationLifetime.InstancePerThread);
        }
    }
}
