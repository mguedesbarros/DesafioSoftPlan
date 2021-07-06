using SoftPlanService.Interfaces;
using System;

namespace SoftPlanService
{
    public class TaxaJurosService : ITaxaJurosService
    {
        public decimal GetTaxaJuros()
        {
            return 0.01M;
        }
    }
}
