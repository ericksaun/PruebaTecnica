using Domain.PruebaTecnica.Interfaces;
using Domain.PruebaTecnica.Models;

namespace Application.Module
{
    public class ClientServices:IClientServices
    {
        private readonly IUnitOfWork _unitOfWork;
        public ClientServices( IUnitOfWork unitOfWork)
        {
            _unitOfWork=unitOfWork;
            
        }
        /// <summary>
        /// Obtiene todos los clientes
        /// </summary>
        /// <returns></returns>
        public IEnumerable<Clientes> GetClientes()
        {
            return _unitOfWork.clientes.GetAll();
        }

        /// <summary>
        /// Metodo que inserta un nuevo cliente
        /// </summary>
        /// <param name="cliente">cliente</param>
        public void insertClient(Clientes cliente)
        {
            _unitOfWork.clientes.Add(cliente);
            _unitOfWork.Complete();

        }
        /// <summary>
        /// Metodo que elimina un cliente
        /// </summary>
        /// <param name="cliente"></param>
        public void removeClient(Clientes cliente)
        {
            _unitOfWork.clientes.Remove(cliente);
            _unitOfWork.Complete();
        }
        /// <summary>
        /// Metodo que actualiza un cliente
        /// </summary>
        /// <param name="cliente"></param>
        public void UpdateClient(Clientes cliente)
        {
            _unitOfWork.clientes.Update(cliente);
            _unitOfWork.Complete();
        }
    }
}