using Domain.PruebaTecnica.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Module
{
    public interface IAccountsServices
    {
        IEnumerable<Cuentas> GetAccountsByIdClient(int IdCliente);
        void insertAccount(Cuentas cuenta);
        void removeAccount(Cuentas cuenta);
        void UpdateAccount(Cuentas cuenta);
    }
}
