using Domain.PruebaTecnica.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain.PruebaTecnica.Interfaces
{
    public interface IMovementsRepository:IGenericRepository<Movimientos>
    {
        IEnumerable<Movimientos> GetMovementsbyUserAndRangeOfDate(int IdUser, DateTime fecha_movimientos_inicial, DateTime fecha_movimientos_final);
        Movimientos PutLastBalanceMovement(Movimientos movimiento);
        double GetDailyQuota(int IdUser);
    }
}
