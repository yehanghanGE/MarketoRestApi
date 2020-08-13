using Marketo.ApiLibrary.Asset.Folders;
using Marketo.ApiLibrary.Asset.Folders.Request;
using Marketo.ApiLibrary.Asset.Folders.RequestProcessor;
using Marketo.ApiLibrary.Asset.Folders.RequestProvider;
using Marketo.ApiLibrary.Asset.SmartLists;
using Marketo.ApiLibrary.Asset.SmartLists.Request;
using Marketo.ApiLibrary.Asset.SmartLists.RequestProcessor;
using Marketo.ApiLibrary.Asset.SmartLists.RequestProvider;
using Marketo.ApiLibrary.Common.Configuration;
using Marketo.ApiLibrary.Common.Data;
using Marketo.ApiLibrary.Common.Http.Data;
using Marketo.ApiLibrary.Common.Http.Oauth;
using Marketo.ApiLibrary.Common.Http.Services;
using Marketo.ApiLibrary.Common.Logging;
using Marketo.ApiLibrary.Leads.BulkExportLeads;
using Marketo.ApiLibrary.Leads.BulkExportLeads.Request;
using Marketo.ApiLibrary.Leads.BulkExportLeads.RequestProcessor;
using Marketo.ApiLibrary.Leads.BulkExportLeads.RequestProvider;

namespace Marketo.ApiLibrary.Common.DI
{
    public class MarketoApiControllerModule : IMarketoApiModule
    {
        public void Initialize(IMarketoApiContainer container)
        {
            container.RegisterType<IMarketoDataProvider, MarketoDataProvider>(RegistrationLifetime.InstancePerThread);
            container.RegisterType<IConfigurationProvider, ConfigurationProvider2>(RegistrationLifetime.InstancePerThread);
            container.RegisterType<ILoggingService<CommerceLog>, CommerceLogService>(RegistrationLifetime.InstancePerThread);
            container.RegisterType<IHttpApiDataProvider, HttpApiDataProvider>(RegistrationLifetime.InstancePerThread);
            container.RegisterType<IHttpClientFactory, HttpClientFactory>(RegistrationLifetime.InstancePerThread);
            container.RegisterType<IAuthenticationTokenProvider, AuthenticationTokenProvider>(RegistrationLifetime.InstancePerThread);
            container.RegisterType<IOAuthTokenCacheService, OAuthTokenCacheService>(RegistrationLifetime.InstancePerThread);
            container.RegisterType<IOAuthTokenRepository, OAuthTokenRepository>(RegistrationLifetime.InstancePerThread);
            container.RegisterType<IConfigurationProvider, ConfigurationProvider2>(RegistrationLifetime.InstancePerThread);

            container.RegisterType<ISmartListController, SmartListController>(RegistrationLifetime.InstancePerThread);
            container.RegisterType<IFolderController, FolderController>(RegistrationLifetime.InstancePerThread);
            container.RegisterType<IBulkExportLeadsController, BulkExportLeadsController>(RegistrationLifetime.InstancePerThread);

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
            container.RegisterType<IHttpRequestProvider<GetFolderContentsRequest>, GetFolderContentsRequestProvider>(RegistrationLifetime.InstancePerThread);
            container.RegisterType<IHttpRequestProvider<DeleteFolderRequest>, DeleteFolderRequestProvider>(RegistrationLifetime.InstancePerThread);
            container.RegisterType<IHttpRequestProvider<CreateFolderRequest>, CreateFolderRequestProvider>(RegistrationLifetime.InstancePerThread);
            container.RegisterType<IHttpRequestProvider<UpdateFolderMetadataRequest>, UpdateFolderMetadataRequestProvider>(RegistrationLifetime.InstancePerThread);
            container.RegisterType<GetFoldersProcessor>(RegistrationLifetime.InstancePerThread);
            container.RegisterType<GetFolderByNameProcessor>(RegistrationLifetime.InstancePerThread);
            container.RegisterType<GetFolderByIdProcessor>(RegistrationLifetime.InstancePerThread);
            container.RegisterType<GetFolderContentsProcessor>(RegistrationLifetime.InstancePerThread);
            container.RegisterType<DeleteFolderProcessor>(RegistrationLifetime.InstancePerThread);
            container.RegisterType<CreateFolderProcessor>(RegistrationLifetime.InstancePerThread);
            container.RegisterType<UpdateFolderMetadataProcessor>(RegistrationLifetime.InstancePerThread);

            container.RegisterType<IHttpRequestProvider<CreateExportLeadJobRequest>, CreateExportLeadJobRequestProvider>(RegistrationLifetime.InstancePerThread);
            container.RegisterType<CreateExportLeadJobProcessor>(RegistrationLifetime.InstancePerThread);

        }
    }
}
