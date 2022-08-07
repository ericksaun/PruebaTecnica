using Domain.PruebaTecnica.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Module
{
    public interface IClientServices
    {
        IEnumerable<Clientes> GetClientes();
        void insertClient(Clientes cliente);
        void removeClient(Clientes cliente);
        void UpdateClient(Clientes cliente);

    }
}
