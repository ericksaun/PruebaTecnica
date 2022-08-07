using Domain.PruebaTecnica.Interfaces;
using Infrastructure.DataAccess.EFCore.Repositories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Infrastructure.DataAccess.EFCore.UnitOfWork
{
    public class UnitOfWork: IUnitOfWork
    {
        private readonly ApplicationContext _context;
        public UnitOfWork(ApplicationContext context)
        {
            _context = context;
            clientes = new ClientRepository(_context);
            cuentas = new AccountsRepository(_context);
            movimientos=new MovementsRepository(_context);

        }
        public IClientRepository clientes { get; private set; }
        public IAccountsRepository cuentas { get; private set; }
        public IMovementsRepository movimientos { get; private set; }

        public int Complete()
        {
            return _context.SaveChanges();
        }
        public void Dispose()
        {
            _context.Dispose();
        }
    }
}
