using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using SoftPlanService.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Threading.Tasks;

namespace TaxaJurosAPI.Controllers
{
    [ApiController]
    [Route("[api/controller]")]
    public class TaxaJurosController : ControllerBase
    {       
        private readonly ILogger<TaxaJurosController> _logger;
        private readonly ITaxaJurosService _taxaJurosService;

        public TaxaJurosController(ILogger<TaxaJurosController> logger,
            ITaxaJurosService taxaJurosService)
        {
            _logger = logger;
            _taxaJurosService = taxaJurosService;
        }

        [HttpGet]
        [Route("taxaJuros")]
        [ProducesResponseType(typeof(decimal), (int)HttpStatusCode.OK)]
        public ActionResult Get()
        {
            var taxa = _taxaJurosService.GetTaxaJuros();

            return Ok(taxa);
        }
    }
}
