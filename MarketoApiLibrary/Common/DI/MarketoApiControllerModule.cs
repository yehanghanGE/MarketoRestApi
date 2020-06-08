using MarketoApiLibrary.Asset.Folders;
using MarketoApiLibrary.Asset.Folders.Request;
using MarketoApiLibrary.Asset.Folders.RequestProcessor;
using MarketoApiLibrary.Asset.Folders.RequestProvider;
using MarketoApiLibrary.Asset.SmartLists;
using MarketoApiLibrary.Asset.SmartLists.Request;
using MarketoApiLibrary.Asset.SmartLists.RequestProcessor;
using MarketoApiLibrary.Asset.SmartLists.RequestProvider;
using MarketoApiLibrary.Common.Configuration;
using MarketoApiLibrary.Common.Data;
using MarketoApiLibrary.Common.Http.Data;
using MarketoApiLibrary.Common.Http.Oauth;
using MarketoApiLibrary.Common.Http.Services;
using MarketoApiLibrary.Common.Logging;

namespace MarketoApiLibrary.Common.DI
{
    public class MarketoApiControllerModule : IMarketoApiModule
    {
        public void Initialize(IMarketoApiContainer container)
        {
            container.RegisterType<ISmartListController, SmartListController>(RegistrationLifetime.InstancePerThread);
            container.RegisterType<IFolderController, FolderController>(RegistrationLifetime.InstancePerThread);

            container.RegisterType<IMarketoDataProvider, MarketoDataProvider>(RegistrationLifetime.InstancePerThread);
            container.RegisterType<IConfigurationProvider, ConfigurationProvider2>(RegistrationLifetime.InstancePerThread);
            container.RegisterType<ILoggingService<CommerceLog>, CommerceLogService>(RegistrationLifetime.InstancePerThread);
            container.RegisterType<IHttpApiDataProvider, HttpApiDataProvider>(RegistrationLifetime.InstancePerThread);
            container.RegisterType<IHttpClientFactory, HttpClientFactory>(RegistrationLifetime.InstancePerThread);
            container.RegisterType<IAuthenticationTokenProvider, AuthenticationTokenProvider>(RegistrationLifetime.InstancePerThread);
            container.RegisterType<IOAuthTokenCacheService, OAuthTokenCacheService>(RegistrationLifetime.InstancePerThread);
            container.RegisterType<IOAuthTokenRepository, OAuthTokenRepository>(RegistrationLifetime.InstancePerThread);
            container.RegisterType<IConfigurationProvider, ConfigurationProvider2>(RegistrationLifetime.InstancePerThread);

            container.RegisterType<IHttpRequestProvider<GetSmartListsRequest>, GetSmartListsRequestProvider>(RegistrationLifetime.InstancePerThread);
            container.RegisterType<IHttpRequestProvider<GetSmartListByIdRequest>, GetSmartListByIdRequestProvider>(RegistrationLifetime.InstancePerThread);
            container.RegisterType<IHttpRequestProvider<GetSmartListByNameRequest>, GetSmartListByNameRequestProvider>(RegistrationLifetime.InstancePerThread);
            container.RegisterType<IHttpRequestProvider<DeleteSmartListRequest>, DeleteSmartListRequestProvider>(RegistrationLifetime.InstancePerThread);
            container.RegisterType<IHttpRequestProvider<CloneSmartListRequest>, CloneSmartListRequestProvider>(RegistrationLifetime.InstancePerThread);
            container.RegisterType<GetSmartListsProcessor>(RegistrationLifetime.InstancePerThread);
            container.RegisterType<GetSmartListByIdProcessor>(RegistrationLifetime.InstancePerThread);
            container.RegisterType<GetSmartListByNameProcessor>(RegistrationLifetime.InstancePerThread);
            container.RegisterType<DeleteSmartListProcessor>(RegistrationLifetime.InstancePerThread);
            container.RegisterType<CloneSmartListProcessor>(RegistrationLifetime.InstancePerThread);

            container.RegisterType<IHttpRequestProvider<GetFoldersRequest>, GetFoldersRequestProvider>(RegistrationLifetime.InstancePerThread);
            container.RegisterType<IHttpRequestProvider<GetFolderByNameRequest>, GetFolderByNameRequestProvider>(RegistrationLifetime.InstancePerThread);
            container.RegisterType<IHttpRequestProvider<GetFolderByIdRequest>, GetFolderByIdRequestProvider>(RegistrationLifetime.InstancePerThread);
            container.RegisterType<GetFoldersProcessor>(RegistrationLifetime.InstancePerThread);
            container.RegisterType<GetFolderByNameProcessor>(RegistrationLifetime.InstancePerThread);
            container.RegisterType<GetFolderByIdProcessor>(RegistrationLifetime.InstancePerThread);
        }
    }
}
