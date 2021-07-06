using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace CalculoJurosAPI.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class CalculoJurosController : ControllerBase
    { 
        private readonly ILogger<CalculoJurosController> _logger;

        public CalculoJurosController(ILogger<CalculoJurosController> logger)
        {
            _logger = logger;
        }        
    }
}
