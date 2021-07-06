using Microsoft.Extensions.DependencyInjection;
using Moq;
using SoftPlanService;
using SoftPlanService.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TaxaJurosAPI.Controllers;
using Xunit;

namespace TaxaJurosAPI.UnitTests
{
    public class TaxaJurosServiceTest
    {
        [Fact(DisplayName = "Taxa de juros retornando com sucesso")]
        public void CalcularTaxaJuros_Success_Test()
        {
            var jurosService = new TaxaJurosService();


            var result =  jurosService.GetTaxaJuros();

            Assert.Equal(0.01M, result);
        }

        [Fact(DisplayName = "Taxa de juros retornando com erro")]
        public void CalcularTaxaJuros_Error_Test()
        {
            var jurosService = new TaxaJurosService();

            var result =  jurosService.GetTaxaJuros();

            Assert.NotEqual(0.02M, result);
        }
    }
}
