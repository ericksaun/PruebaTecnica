using Domain.PruebaTecnica.Interfaces;
using Domain.PruebaTecnica.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Module
{
    public class AccountsServices:IAccountsServices
    {


        private readonly IUnitOfWork _unitOfWork;
        public AccountsServices(IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;

        }
        /// <summary>
        /// Metodo que trae todas la cuentas 
        /// </summary>
        /// <returns></returns>
        public IEnumerable<Cuentas> GetAccountsByIdClient(int IdCliente)
        {

            return _unitOfWork.cuentas.GetAccountsByClient(IdCliente);
        }

        /// <summary>
        /// Metodo que inserta una nueva cuenta
        /// </summary>
        /// <param name="cuenta">cuenta</param>
        public void insertAccount(Cuentas cuenta)
        {
            _unitOfWork.cuentas.Add(cuenta);
            _unitOfWork.Complete();

        }
        /// <summary>
        /// Metodo que elimina una cuenta
        /// </summary>
        /// <param name="cuenta">cuenta</param>
        public void removeAccount(Cuentas cuenta)
        {
            _unitOfWork.cuentas.Remove(cuenta);
            _unitOfWork.Complete();
        }
        /// <summary>
        /// Metodo que actualiza una cuenta
        /// </summary>
        /// <param name="cuenta">cuenta</param>
        public void UpdateAccount(Cuentas cuenta)
        {
            _unitOfWork.cuentas.Update(cuenta);
            _unitOfWork.Complete();
        }
    }
}
