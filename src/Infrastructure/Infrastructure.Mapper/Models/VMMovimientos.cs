using Domain.PruebaTecnica.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Infrastructure.Mapper.Models
{
    public class VMMovimientos
    {
        public int Id { get; set; }
        public DateTime fecha { get; set; }
        public string tipo_movimiento { get; set; } = string.Empty;
        public double valor { get; set; }
        public double saldo { get; set; }
        public VMCuentas? cuenta { get; set; }

    }
}
