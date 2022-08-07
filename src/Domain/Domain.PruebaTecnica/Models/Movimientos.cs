using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain.PruebaTecnica.Models
{
    public class Movimientos
    {
        public int Id { get; set; }
        public DateTime mo_fecha { get; set; }
        public string mo_tipo_movimiento { get; set; } = string.Empty;
        public double mo_valor { get; set; }
        public double mo_saldo { get; set; }
        public Cuentas? cuenta { get; set; }
       

    }
}
