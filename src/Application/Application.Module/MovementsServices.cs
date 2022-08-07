using Application.Module.Enums;
using Domain.PruebaTecnica.Interfaces;
using Domain.PruebaTecnica.Models;
using Microsoft.Extensions.Configuration;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Module
{
    public class MovementsServices : IMovementsServices
    {
        private const string msgExceptionTipoTransaccion = "No existe el tipo de transaccion indicadapor favor usar Debito o Credito";
        private const string msgExceptionCupoExcedido = "Cupo diario Excedido";
        private const string msgExceptionSaldoExcedido = "Saldo no disponible";
        
        private const string _cupoDiarioKey = "AppSettings:CupoDiario";
        private readonly string _cupoDiario;
        private readonly IUnitOfWork _unitOfWork;
        public MovementsServices(IUnitOfWork unitOfWork, IConfiguration configuration)
        {
            _unitOfWork = unitOfWork;
            _cupoDiario = configuration.GetSection(_cupoDiarioKey).Value;
        }

        public IEnumerable<Movimientos> GetMovementsbyUserAndRangeOfDate(int IdUser, DateTime fecha_movimientos_inicial, DateTime fecha_movimientos_final)
        {
            return _unitOfWork.movimientos.GetMovementsbyUserAndRangeOfDate(IdUser, fecha_movimientos_inicial, fecha_movimientos_final);
        }

        public void InsertMovements(Movimientos movimiento)
        {
            TipoTransaccion tipoTransaccion;
            bool ValidateTipoTransaccion = Enum.TryParse(movimiento.mo_tipo_movimiento, out tipoTransaccion);
            if (ValidateTipoTransaccion)
            {
                switch (tipoTransaccion)
                {
                    case TipoTransaccion.Debito:
                        {
                            double cupoDiario = _unitOfWork.movimientos.GetDailyQuota(movimiento.cuenta.cliente.Id);
                            if (Math.Abs(cupoDiario) <= Convert.ToDouble(_cupoDiario) && Math.Abs(cupoDiario)+movimiento.mo_valor<= Convert.ToDouble(_cupoDiario))
                            {
                                
                                movimiento = GetLastMovimiento(movimiento);
                                if (movimiento.mo_saldo > 0 && movimiento.mo_saldo >= movimiento.mo_valor)
                                {
                                    double NewSaldo = movimiento.mo_saldo - movimiento.mo_valor;
                                    movimiento.mo_saldo = NewSaldo;
                                    movimiento.mo_valor = movimiento.mo_valor * -1;
                                    _unitOfWork.movimientos.Add(movimiento);
                                    _unitOfWork.Complete();
                                }
                                else
                                {
                                    throw new ArgumentException(msgExceptionSaldoExcedido);
                                }
                            }
                            else
                            {
                                throw new ArgumentException(msgExceptionCupoExcedido);
                            }


                            break;
                        }


                    case TipoTransaccion.Credito:
                        {
                            movimiento = GetLastMovimiento(movimiento);

                            movimiento.mo_saldo = movimiento.mo_saldo + movimiento.mo_valor;

                            _unitOfWork.movimientos.Add(movimiento);
                            _unitOfWork.Complete();
                            break;
                        }
                }
            }
            else
            {
                throw new ArgumentException(msgExceptionTipoTransaccion);
            }


        }
        public Movimientos GetLastMovimiento(Movimientos movimiento)
        {
            return _unitOfWork.movimientos.PutLastBalanceMovement(movimiento);
        }


    }
}
