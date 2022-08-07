using Domain.PruebaTecnica.Interfaces;
using Domain.PruebaTecnica.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Infrastructure.DataAccess.EFCore.Repositories
{
    public class ClientRepository : GenericRepository<Clientes>, IClientRepository

    {
        public ClientRepository(ApplicationContext context) : base(context)
        {

        }
       

    }
}
