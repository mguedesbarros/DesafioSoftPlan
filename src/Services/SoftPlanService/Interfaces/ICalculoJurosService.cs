using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SoftPlanService.Interfaces
{
    public interface ICalculoJurosService
    {
        decimal CalcularJuros(decimal valorInicial, int meses);
    }
}
