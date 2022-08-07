using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain.PruebaTecnica.Interfaces
{
    public interface IUnitOfWork:IDisposable
    {
        IClientRepository clientes { get; }
        IAccountsRepository cuentas { get; }
        IMovementsRepository movimientos { get; }
        int Complete();
    }
}
