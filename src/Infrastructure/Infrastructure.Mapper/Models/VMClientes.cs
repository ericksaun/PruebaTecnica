namespace Infrastructure.Mapper.Models
{
    public class VMClientes: VMPersonas
    {
        public int Id { get; set; }
        public string contraseña { get; set; } = string.Empty;
        public bool estado { get; set; } = true;
    }
}
