using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain.PruebaTecnica.Models
{
    public class Cuentas
    {
        public int Id { get; set; }
        public Int64 cu_numero_cuenta { get; set; }
        public string cu_tipo_cuenta { get; set; } = string.Empty;
        public double cu_saldo_inicial { get; set; }
        public bool cu_estado { get; set; } = true;
        public Clientes? cliente { get; set; }
    }
}
