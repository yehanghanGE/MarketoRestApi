using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;
using Marketo.ApiLibrary.Lead.Leads;
using Marketo.ApiLibrary.Lead.Leads.Response;
using Microsoft.Extensions.Logging;

namespace Marketo.Angular.Controllers
{
    [Route("[controller]")]
    [ApiController]
    public class MarketoLeadsController : ControllerBase
    {
        private readonly ILogger<MarketoLeadsController> _logger;

        public MarketoLeadsController(ILogger<MarketoLeadsController> logger)
        {
            _logger = logger;
        }

        [HttpGet]
        public IEnumerable<LeadAttribute> Get()
        {
            var response = Leads.DescibeLead();
            return response.Result;
        }
    }
}
