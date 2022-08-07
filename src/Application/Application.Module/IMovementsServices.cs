using Domain.PruebaTecnica.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Module
{
    public interface IMovementsServices
    {
        IEnumerable<Movimientos> GetMovementsbyUserAndRangeOfDate(int IdUser, DateTime fecha_movimientos_inicial, DateTime fecha_movimientos_final);
        void InsertMovements(Movimientos movimiento);
        Movimientos GetLastMovimiento(Movimientos movimiento);
    }
}
