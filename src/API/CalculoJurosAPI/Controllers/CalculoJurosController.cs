using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using SoftPlanService.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Threading.Tasks;

namespace CalculoJurosAPI.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class CalculoJurosController : ControllerBase
    { 
        private readonly ILogger<CalculoJurosController> _logger;
        private readonly ICalculoJurosService _calculoJurosService;

        public CalculoJurosController(ILogger<CalculoJurosController> logger,
            ICalculoJurosService calculoJurosService)
        {
            _logger = logger;
            _calculoJurosService = calculoJurosService;
        }

        [HttpGet]
        [Route("valorInicial/{valorInicial}/meses/{meses}")]
        [ProducesResponseType(typeof(decimal), (int)HttpStatusCode.OK)]
        [ProducesResponseType((int)HttpStatusCode.BadRequest)]
        public ActionResult Get(decimal valorInicial, int meses)
        {
            var calculo = _calculoJurosService.CalcularJuros(valorInicial, meses);

            return Ok(calculo);
        }
    }
}
