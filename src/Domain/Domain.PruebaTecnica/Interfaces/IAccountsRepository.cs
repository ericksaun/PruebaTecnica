using Domain.PruebaTecnica.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain.PruebaTecnica.Interfaces
{
    public interface IAccountsRepository:IGenericRepository<Cuentas>
    {
        IEnumerable<Cuentas> GetAccountsByClient(int idCliente);
    }
}
