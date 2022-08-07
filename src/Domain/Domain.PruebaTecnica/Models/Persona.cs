using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain.PruebaTecnica.Models
{
    public class Persona
    {
        public string pr_nombre { get; set; } = string.Empty;
        public string pr_genero { get; set; } = string.Empty;
        public int pr_edad { get; set; }
        public string pr_direccion { get; set; } = string.Empty;
        public string pr_identificacion { get; set; } = string.Empty;
        public string pr_telefono { get; set; } = string.Empty;
    }
}
