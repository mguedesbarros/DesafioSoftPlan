using SoftPlanService;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Xunit;

namespace CalculoJurosAPI.UnitTests
{    
    public class CalculoJurosServiceTest
    {
        private readonly TaxaJurosService _taxaJurosService;
        private readonly CalculoJurosService _calculoJurosService;

        public CalculoJurosServiceTest()
        {
            _taxaJurosService = new TaxaJurosService();
            _calculoJurosService = new CalculoJurosService(_taxaJurosService);
        }

        [Fact(DisplayName = "Calcular Juros retornando com sucesso")]
        public void CalcularJuros_Success_Test()
        {
            var meses = 5;
            var valorInicial = 100;

            var result =  _calculoJurosService.CalcularJuros(valorInicial, meses);

            Assert.Equal(105.10M, result);
        }

        [Fact(DisplayName = "Calcular Juros retornando exception valor inicial negativo")]
        public void CalcularJuros_ValorInicial_Negativo_Test()
        {
            var meses = 5;
            var valorInicial = -1;

            Assert.Throws<ArgumentOutOfRangeException>(() => _calculoJurosService.CalcularJuros(valorInicial, meses));
        }
        
        [Fact(DisplayName = "Calcular Juros retornando exception valor inicial zerado")]
        public void CalcularJuros_ValorInicial_Zerado_Test()
        {
            var meses = 5;
            var valorInicial = 0;

            Assert.Throws<ArgumentOutOfRangeException>(() => _calculoJurosService.CalcularJuros(valorInicial, meses));
        }

        [Fact(DisplayName = "Calcular Juros retornando exception Meses negativo")]
        public void CalcularJuros_Meses_Negativo_Test()
        {
            var meses = -5;
            var valorInicial = 100;

            Assert.Throws<ArgumentOutOfRangeException>(() => _calculoJurosService.CalcularJuros(valorInicial, meses));
        }

        [Fact(DisplayName = "Calcular Juros retornando exception meses zerado")]
        public void CalcularJuros_Meses_Zerado_Test()
        {
            var meses = 0;
            var valorInicial = 100;

            Assert.Throws<ArgumentOutOfRangeException>(() => _calculoJurosService.CalcularJuros(valorInicial, meses));
        }        
    }
}
