using SoftPlanService.Interfaces;
using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SoftPlanService
{
    public class CalculoJurosService : ICalculoJurosService
    {
        private readonly ITaxaJurosService _taxaJurosService;

        public CalculoJurosService(ITaxaJurosService taxaJurosService)
        {
            _taxaJurosService = taxaJurosService;
        }

        public decimal CalcularJuros(decimal valorInicial, int meses)
        {
            var taxaJuros = _taxaJurosService.GetTaxaJuros();

            ValidarDadosCalculo(valorInicial, meses, taxaJuros);

            return CalcularJurosComposto(Convert.ToDouble(valorInicial), meses, Convert.ToDouble(taxaJuros));
        }

        private static decimal CalcularJurosComposto(double valorInicial, int meses, double taxaJuros)
        {
            var valorFinal  = valorInicial * Math.Pow((1 + taxaJuros), meses);

            return Convert.ToDecimal(valorFinal.ToString("N2"));
        }

        private static void ValidarDadosCalculo(decimal valorInicial, int meses, decimal taxaJuros)
        {
            if (valorInicial == 0)
                throw new ArgumentOutOfRangeException(nameof(valorInicial), valorInicial, "Valor inicial não pode ser igual a zero");
            else if (valorInicial < 0)
                throw new ArgumentOutOfRangeException(nameof(valorInicial), valorInicial, "Valor inicial não pode ser negativo");
            else if (meses == 0)
                throw new ArgumentOutOfRangeException(nameof(meses), meses, "Quantidade de meses não pode ser igual a zero");
            else if (meses < 0)
                throw new ArgumentOutOfRangeException(nameof(meses), meses, "Quantidade de meses não pode ser negativo");
            else if (taxaJuros == 0)
                throw new InvalidOperationException("A Taxa de Juros não pode ser igual a zero");
            else if (taxaJuros < 0)
                throw new InvalidOperationException("A Taxa de Juros não pode ser negativo");
        }
    }
}
