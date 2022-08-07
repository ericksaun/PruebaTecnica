using Domain.PruebaTecnica.Models;
using Microsoft.EntityFrameworkCore;

namespace Infrastructure.DataAccess.EFCore
{
    public class ApplicationContext:DbContext
    {
        public ApplicationContext(DbContextOptions<ApplicationContext> options) : base(options)
        {
        }
        public DbSet<Clientes> clientes { get; set; }
        public DbSet<Cuentas> cuentas { get; set; }
        public DbSet<Movimientos> movimientos { get; set; }

    }
}