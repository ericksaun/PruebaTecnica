using Application.Module;
using AutoMapper;
using Domain.LoggingService.Core;
using Domain.PruebaTecnica.Models;
using Infraestructure.LoggingService.Clases;
using Infrastructure.Mapper.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System.Reflection;

namespace PruebaTecnica.Controller
{
    [Route("api/[controller]/[Action]")]
    [ApiController]
    public class MovimientosController : ControllerBase
    {
        private const string MsgError = "Ocurrio un error en";
        private const string ErrorKey = "Error_";
        private const string DebugKey = "Debug_";
        private readonly string NameClass;

        private readonly ILogging _logging;
        private IMapper _mapper;
        private readonly IMovementsServices _movementsServices;
        public MovimientosController(IMovementsServices movementsServices,ILogging logging,IMapper mapper)
        {
            _logging=logging;
            _movementsServices=movementsServices;
            _mapper=mapper;
            NameClass = GetType().Name;
        }
        /// <summary>
        /// Metodo que inserta Movimientos de cliente
        /// </summary>
        /// <param name="VMmovimiento">VMmovimiento</param>
        /// <returns></returns>
        [HttpPost]
        public IActionResult InsertMovements([FromBody]VMMovimientos VMmovimiento)
        {
            try
            {
                _logging.RegisterLog(TipoLoggeo.Debug, $"Inicia InsertMovements", $"{DebugKey}{NameClass}");
                Movimientos movimiento = _mapper.Map<Movimientos>(VMmovimiento);
                _logging.RegisterLog(TipoLoggeo.Debug, $"Mapper VMmovimiento => movimiento", $"{DebugKey}{NameClass}");
                Movimientos LastMov = _movementsServices.GetLastMovimiento(movimiento);
                _logging.RegisterLog(TipoLoggeo.Debug, $"Select Ejecutado", $"{DebugKey}{NameClass}");
                _movementsServices.InsertMovements(LastMov);
                _logging.RegisterLog(TipoLoggeo.Debug, $"Insert Ejecutado", $"{DebugKey}{NameClass}");
                return Ok();
            }
            catch(Exception ex)
            {
                _logging.RegisterLog<IMovementsServices>(TipoLoggeo.Error, $"{MsgError} {MethodBase.GetCurrentMethod().Name}", $"{ErrorKey}{NameClass}", _movementsServices, ex);
                return BadRequest(ex.Message);
            }


        }
        /// <summary>
        /// Genera reporte Estado de Cuenta
        /// </summary>
        /// <param name="IdUser"></param>
        /// <param name="fecha_movimientos_inicial"></param>
        /// <param name="fecha_movimientos_final"></param>
        /// <returns></returns>
        [HttpGet]
        public IActionResult Reporte([FromQuery]int IdUser, [FromQuery] DateTime fecha_movimientos_inicial, [FromQuery] DateTime fecha_movimientos_final)
        {
            IEnumerable<Movimientos> reporte = _movementsServices.GetMovementsbyUserAndRangeOfDate(IdUser, fecha_movimientos_inicial, fecha_movimientos_final);
            IEnumerable<VmReporteMovimientos> movimientosReporte =_mapper.Map<IEnumerable<VmReporteMovimientos>>(reporte);
            return Ok(movimientosReporte);
        }
    }
}
