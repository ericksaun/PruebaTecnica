using Domain.PruebaTecnica.Interfaces;
using Domain.PruebaTecnica.Models;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Infrastructure.DataAccess.EFCore.Repositories
{
    public class AccountsRepository : GenericRepository<Cuentas>, IAccountsRepository
    {
        public AccountsRepository(ApplicationContext context) : base(context)
        {

        }
        public IEnumerable<Cuentas> GetAccountsByClient(int idCliente)
        {
            return _context.cuentas.Where(x => x.cliente.Id == idCliente).Include(y => y.cliente);
        }

       
    }

}
