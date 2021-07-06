using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace TaxaJurosAPI.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class TaxaJurosController : ControllerBase
    {       

        private readonly ILogger<TaxaJurosController> _logger;

        public TaxaJurosController(ILogger<TaxaJurosController> logger)
        {
            _logger = logger;
        }
    }
}
