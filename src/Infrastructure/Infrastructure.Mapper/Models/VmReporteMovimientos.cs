using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Infrastructure.Mapper.Models
{
    public class VmReporteMovimientos
    {
        public DateTime Fecha { get; set; }
        public string Cliente { get; set; } = string.Empty;
        public Int64 NumeroCuenta { get; set; }
        public string Tipo { get; set; } = string.Empty;
        public double SaldoInicial { get; set; }
        public bool Estado { get; set; } = true;
        public double Movimiento { get; set; }
        public double SaldoDisponible { get; set; }
     
    }
}
