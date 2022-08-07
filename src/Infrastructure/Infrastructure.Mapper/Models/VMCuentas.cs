using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Infrastructure.Mapper.Models
{
    public class VMCuentas
    {
        public int Id { get; set; }
        public Int64 numero_cuenta { get; set; }
        public string tipo_cuenta { get; set; } = string.Empty;
        public double saldo_inicial { get; set; }
        public bool estado { get; set; } = true;
        public VMClientes? cliente { get; set; }
    }
}
