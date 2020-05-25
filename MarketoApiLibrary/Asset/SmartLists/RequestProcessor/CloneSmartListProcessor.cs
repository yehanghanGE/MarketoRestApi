﻿using MarketoApiLibrary.Asset.SmartLists.Request;
using MarketoApiLibrary.Asset.SmartLists.Response;
using MarketoApiLibrary.Common.Data;
using MarketoApiLibrary.Common.Http.Services;
using MarketoApiLibrary.Common.Logging;
using MarketoApiLibrary.Common.Processor;

namespace MarketoApiLibrary.Asset.SmartLists.RequestProcessor
{
    public class CloneSmartListProcessor : MarketoHttpRequestProcessor<CloneSmartListRequest, SmartListsResponse>
    {
        public CloneSmartListProcessor(
            IHttpRequestProvider<CloneSmartListRequest> requestProvider,
            IMarketoDataProvider dataProvider,
            ILoggingService<CommerceLog> commerceLogger,
            ILoggingService<SynchronizationLog> syncLogger) :
            base(requestProvider, dataProvider, commerceLogger, syncLogger)
        {
        }
    }
}
