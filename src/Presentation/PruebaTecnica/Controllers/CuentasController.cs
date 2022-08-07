using AutoMapper;
using Domain.PruebaTecnica.Models;
using Microsoft.AspNetCore.Mvc;
using Application.Module;
using Infrastructure.Mapper.Models;
using Domain.LoggingService.Core;
using Infraestructure.LoggingService.Clases;
using System.Reflection;

namespace PruebaTecnica.Controller
{
    [Route("api/[controller]/[Action]")]
    [ApiController]
    public class CuentasController : ControllerBase
    {
        private const string MsgError = "Ocurrio un error en";
        private const string ErrorKey = "Error_";
        private const string DebugKey = "Debug_";
        private readonly string NameClass;

        public readonly IMapper _mapper;
        public readonly IAccountsServices _accountsServices;
        public readonly ILogging _logging;

        public CuentasController(IMapper mapper, IAccountsServices accountsServices, ILogging logging)
        {
            _mapper = mapper;
            _accountsServices = accountsServices;
            _logging = logging;
            NameClass = GetType().Name;
        }
        /// <summary>
        /// Metodo que obtiene todas las cuentas de un cliente
        /// </summary>
        /// <param name="IdCliente">IdCliente</param>
        /// <returns></returns>
        [HttpGet]
        public IActionResult GetAccountsByIdClient([FromQuery] int IdCliente)
        {
            try
            {
                _logging.RegisterLog(TipoLoggeo.Debug, $"Inicia GetAccountsByIdClient", $"{DebugKey}{NameClass}");
                IEnumerable<Cuentas> cuentas = _accountsServices.GetAccountsByIdClient(IdCliente);
                _logging.RegisterLog(TipoLoggeo.Debug, $"Mapper IEnumerable<Cuentas> => ICollection<VMCuentas>", $"{DebugKey}{NameClass}");
                var VMcuentas = _mapper.Map<ICollection<VMCuentas>>(cuentas);
                _logging.RegisterLog(TipoLoggeo.Debug, $"Select Ejecutado", $"{DebugKey}{NameClass}");

                return Ok(VMcuentas);
            }
            catch (Exception ex)
            {
                _logging.RegisterLog<IAccountsServices>(TipoLoggeo.Error, $"{MsgError} {MethodBase.GetCurrentMethod().Name}", $"{ErrorKey}{NameClass}", _accountsServices, ex);

                return BadRequest(ex.Message);
            }


        }


        /// <summary>
        /// Metodo que crea una cuenta de un usuario
        /// </summary>
        /// <param name="vmCuentas">vmCuentasparam>
        /// <returns></returns>
        [HttpPost]
        public IActionResult InsertAccount([FromBody] VMCuentas vmCuentas)
        {
            try
            {
                _logging.RegisterLog(TipoLoggeo.Debug, $"Inicia InsertAccount", $"{DebugKey}{NameClass}");
                Cuentas cuenta = _mapper.Map<Cuentas>(vmCuentas);
                _logging.RegisterLog(TipoLoggeo.Debug, $"Mapper VMCuentas => Cuentas", $"{DebugKey}{NameClass}");
                _accountsServices.insertAccount(cuenta);
                _logging.RegisterLog(TipoLoggeo.Debug, $"Insert Ejecutado", $"{DebugKey}{NameClass}");

                return Ok();
            }
            catch(Exception ex)
            {
                _logging.RegisterLog<IAccountsServices>(TipoLoggeo.Error, $"{MsgError} {MethodBase.GetCurrentMethod().Name}", $"{ErrorKey}{NameClass}", _accountsServices, ex);

                return BadRequest(ex.Message);
            }
        }
        /// <summary>
        /// Metodo que actualiza Cuenta existente
        /// </summary>
        /// <param name="vmCuentas">vmCuentas</param>
        /// <returns></returns>
        [HttpPut]
        public IActionResult UpdateAccount([FromBody] VMCuentas vmCuentas)
        {
            try
            {
                _logging.RegisterLog(TipoLoggeo.Debug, $"Inicia UpdateAccount", $"{DebugKey}{NameClass}");
                Cuentas cuenta = _mapper.Map<Cuentas>(vmCuentas);
                _logging.RegisterLog(TipoLoggeo.Debug, $"Mapper VMCuentas => Cuentas", $"{DebugKey}{NameClass}");
                _accountsServices.UpdateAccount(cuenta);
                _logging.RegisterLog(TipoLoggeo.Debug, $"Update Ejecutado", $"{DebugKey}{NameClass}");
                return Ok();
            }
            catch(Exception ex)
            {
                _logging.RegisterLog<IAccountsServices>(TipoLoggeo.Error, $"{MsgError} {MethodBase.GetCurrentMethod().Name}", $"{ErrorKey}{NameClass}", _accountsServices, ex);

                return BadRequest(ex.Message);

            }
        }
        /// <summary>
        /// Metodo que elimina cuenta existente
        /// </summary>
        /// <param name="vmCuentas">vmCuentas</param>
        /// <returns></returns>
        [HttpDelete]
        public IActionResult DeleteAccount([FromBody] VMCuentas vmCuentas)
        {
            try
            {
                _logging.RegisterLog(TipoLoggeo.Debug, $"Inicia DeleteAccount", $"{DebugKey}{NameClass}");
                Cuentas cuenta = _mapper.Map<Cuentas>(vmCuentas);
                _logging.RegisterLog(TipoLoggeo.Debug, $"Mapper VMCuentas => Cuentas", $"{DebugKey}{NameClass}");
                _accountsServices.removeAccount(cuenta);
                _logging.RegisterLog(TipoLoggeo.Debug, $"Delete Ejecutado", $"{DebugKey}{NameClass}");
                return Ok();
            }
            catch (Exception ex)
            {
                _logging.RegisterLog<IAccountsServices>(TipoLoggeo.Error, $"{MsgError} {MethodBase.GetCurrentMethod().Name}", $"{ErrorKey}{NameClass}", _accountsServices, ex);

                return BadRequest(ex.Message);
            }
        }
    }
}
