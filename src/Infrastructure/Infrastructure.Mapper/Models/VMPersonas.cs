using System.ComponentModel.DataAnnotations;

namespace Infrastructure.Mapper.Models
{
    public class VMPersonas
    {
        public string nombre { get; set; } = string.Empty;
        public string genero { get; set; } = string.Empty;
        public int edad { get; set; }
        public string identificacion { get; set; } = string.Empty;
        public string telefono { get; set; } = string.Empty;
        public string direccion { get; set; } = string.Empty;
    }
}
