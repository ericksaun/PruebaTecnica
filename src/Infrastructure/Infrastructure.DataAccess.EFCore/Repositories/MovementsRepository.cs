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
    public class MovementsRepository : GenericRepository<Movimientos>, IMovementsRepository
    {
        public MovementsRepository(ApplicationContext context) : base(context)
        {

        }

        public IEnumerable<Movimientos> GetMovementsbyUserAndRangeOfDate(int IdUser, DateTime fecha_movimientos_inicial, DateTime fecha_movimientos_final)
        {
            return _context.movimientos
                .Where(x => x.cuenta.cliente.Id == IdUser && x.mo_fecha.Date >= fecha_movimientos_inicial.Date && x.mo_fecha.Date <= fecha_movimientos_final.Date)
                .Include(x => x.cuenta)
                .Include(x => x.cuenta.cliente);
        }
       
        public Movimientos PutLastBalanceMovement(Movimientos movimiento)
        {
            
            Cuentas? cuentas = null;
            IEnumerable<Movimientos> rowlast = null;
           
                rowlast = (from mov in _context.movimientos
                           where mov.cuenta.cu_numero_cuenta == movimiento.cuenta.cu_numero_cuenta
                           orderby mov.mo_fecha descending
                           select mov).Include(x => x.cuenta).Include(y => y.cuenta.cliente).AsEnumerable();
                if (!rowlast.Any())
                {
                    cuentas = _context.cuentas.Where(x => x.cu_numero_cuenta == movimiento.cuenta.cu_numero_cuenta).Include(x => x.cliente).FirstOrDefault();
                    movimiento.cuenta = cuentas;
                    movimiento.mo_saldo = cuentas.cu_saldo_inicial;
                    movimiento.mo_fecha = DateTime.Now;
                }
                else
                {
                    Movimientos mov = rowlast.FirstOrDefault();
                    movimiento.cuenta = mov.cuenta;
                    movimiento.mo_saldo = mov.mo_saldo;
                    movimiento.mo_fecha = DateTime.Now;
                }

          

          
           

            return movimiento;



        }
        public double GetDailyQuota(int IdUser)
        {
            double cupo = _context.movimientos.Where(x => x.mo_fecha.Date == DateTime.Now.Date && x.cuenta.cliente.Id==IdUser && x.mo_tipo_movimiento== "Debito").Sum(y => y.mo_valor);

            return cupo;

                       

        }

       
    }
}
