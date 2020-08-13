using Marketo.ApiLibrary.Common.Configuration;
using Marketo.ApiLibrary.Common.Http.Oauth;
using Marketo.ApiLibrary.Common.Http.Services;
using Marketo.ApiLibrary.Leads.BulkExportLeads.DTO;
using Marketo.ApiLibrary.Leads.BulkExportLeads.Request;
using Newtonsoft.Json;
using System;
using System.Linq;
using System.Net.Http;
using System.Text;

namespace Marketo.ApiLibrary.Leads.BulkExportLeads.RequestProvider
{
    public class CreateExportLeadJobRequestProvider : BaseHttpRequestProvider<CreateExportLeadJobRequest>
    {
        private readonly IConfigurationProvider _configuration;
        public CreateExportLeadJobRequestProvider(IConfigurationProvider configuration,
            IAuthenticationTokenProvider authenticationTokenProvider) :
            base(configuration, authenticationTokenProvider)
        {
            this._configuration = configuration;
        }

        protected override string GetRelativeUrl(CreateExportLeadJobRequest request)
        {
            return $"/{Constants.UrlSegments.Version}/{Constants.UrlSegments.Leads}/{Constants.UrlSegments.Export}/{Constants.UrlSegments.Create}";
        }

        protected override HttpMethod GetHttpMethod()
        {
            return HttpMethod.Post;
        }

        protected override Uri GetMarketoBaseUri()
        {
            var marketoConfig = this._configuration.LoadConfig();
            return new Uri(new Uri(marketoConfig.Host), marketoConfig.BulkRelativePath);
        }

        protected override HttpContent GetBody(CreateExportLeadJobRequest request)
        {
            var dto = new ExportLeadDto { Fields = request.Fields, Format = request.Format };

            if (request.ColumnHeaderNames != null)
            {
                var columnHeaderNames = request.ColumnHeaderNames.Select(columnHeaderName => new ColumnHeaderNameDto() { Name = columnHeaderName.Name, Value = columnHeaderName.Value }).ToList();

                dto.ColumnHeaderNames = columnHeaderNames;
            }

            if (request.Filter != null)
            {
                var filters = new ExportLeadFilterDto
                {
                    SmartListName = request.Filter?.SmartListName,
                    StaticListName = request.Filter?.StaticListName,
                    SmartListId = request.Filter.SmartListId,
                    StaticListId = request.Filter.StaticListId
                };

                if (request.Filter.CreateAt != null)
                {
                    filters.CreateAt = new DateRangeDto()
                    { StartAt = request.Filter?.CreateAt.StartAt, EndAt = request.Filter?.CreateAt.EndAt };
                }

                if (request.Filter.UpdatedAt != null)
                {
                    filters.UpdatedAt = new DateRangeDto()
                    { StartAt = request.Filter?.UpdatedAt.StartAt, EndAt = request.Filter?.UpdatedAt.EndAt };
                }

                dto.Filter = filters;
            }

            var payload = JsonConvert.SerializeObject(dto);
            return new StringContent(payload, Encoding.UTF8, Constants.MediaTypeNames.Application.Json);
        }
    }
}
