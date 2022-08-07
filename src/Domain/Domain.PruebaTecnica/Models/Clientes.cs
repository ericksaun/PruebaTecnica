using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain.PruebaTecnica.Models
{
    public class Clientes:Persona
    {
        public int Id { get; set; }
        public string cl_contraseña { get; set; } =string.Empty;
        public bool cl_estado { get; set; }=true;
    }
}
