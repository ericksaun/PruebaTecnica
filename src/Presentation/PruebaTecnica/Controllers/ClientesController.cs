using Application.Module;
using AutoMapper;
using Domain.LoggingService.Core;
using Domain.PruebaTecnica.Models;
using Infraestructure.LoggingService.Clases;
using Infrastructure.Mapper.Models;
using Microsoft.AspNetCore.Mvc;
using System.Reflection;

namespace PruebaTecnica.Controller
{
    [Route("api/[controller]/[Action]")]
    [ApiController]
    public class ClientesController : ControllerBase
    {
        private const string MsgError = "Ocurrio un error en";
        private const string ErrorKey = "Error_";
        private const string DebugKey = "Debug_";
        private readonly string NameClass;

        private readonly IClientServices _clientServices;
        public readonly IMapper _mapper;
        public readonly ILogging _logging;
        public ClientesController(IClientServices clientServices, IMapper mapper, ILogging logging)
        {
            _clientServices = clientServices;
            _mapper = mapper;
            _logging= logging;
            NameClass = GetType().Name;
        }
        /// <summary>
        /// Metodo que inserta los clientes
        /// </summary>
        /// <returns></returns>
        [HttpPost]
        public IActionResult InsertClient([FromBody] VMClientes vmcliente)
        {
            try
            {
                _logging.RegisterLog(TipoLoggeo.Debug, $"Inicia InsertClient", $"{DebugKey}{NameClass}");
                Clientes cliente = _mapper.Map<Clientes>(vmcliente);
                _logging.RegisterLog(TipoLoggeo.Debug, $"Mapper vmcliente => cliente", $"{DebugKey}{NameClass}");
                _clientServices.insertClient(cliente);
                _logging.RegisterLog(TipoLoggeo.Debug, $"Insert Ejecutado", $"{DebugKey}{NameClass}");
                return Ok();
            }
            catch (Exception ex)
            {
                _logging.RegisterLog<IClientServices>(TipoLoggeo.Error, $"{MsgError} {MethodBase.GetCurrentMethod().Name}", $"{ErrorKey}{NameClass}", _clientServices, ex);
                return BadRequest(ex.Message);
            }
        }
        /// <summary>
        /// Metodo que actualiza cliente existente
        /// </summary>
        /// <param name="vmcliente">vmcliente</param>
        /// <returns></returns>
        [HttpPut]
        public IActionResult UpdateClient([FromBody] VMClientes vmcliente)
        {
            try
            {
                _logging.RegisterLog(TipoLoggeo.Debug, $"Inicia UpdateClient", $"{DebugKey}{NameClass}");
                Clientes cliente = _mapper.Map<Clientes>(vmcliente);
                _logging.RegisterLog(TipoLoggeo.Debug, $"Mapper vmcliente => cliente", $"{DebugKey}{NameClass}");

                _clientServices.UpdateClient(cliente);
                _logging.RegisterLog(TipoLoggeo.Debug, $"Update Ejecutado", $"{DebugKey}{NameClass}");
                return Ok();
            }
            catch(Exception ex)
            {
                _logging.RegisterLog<IClientServices>(TipoLoggeo.Error, $"{MsgError} {MethodBase.GetCurrentMethod().Name}", $"{ErrorKey}{NameClass}", _clientServices, ex);

                return BadRequest(ex.Message);
            }
        }
        /// <summary>
        /// Metodo que elimina cliente existente
        /// </summary>
        /// <param name="vmcliente">vmcliente</param>
        /// <returns></returns>
        [HttpDelete]
        public IActionResult DeleteClient([FromBody] VMClientes vmcliente)
        {
            try
            {
                _logging.RegisterLog(TipoLoggeo.Debug, $"Inicia DeleteClient", $"{DebugKey}{NameClass}");
                Clientes cliente = _mapper.Map<Clientes>(vmcliente);
                _logging.RegisterLog(TipoLoggeo.Debug, $"Mapper vmcliente => cliente", $"{DebugKey}{NameClass}");
                _clientServices.removeClient(cliente);
                _logging.RegisterLog(TipoLoggeo.Debug, $"Delete Ejecutado", $"{DebugKey}{NameClass}");
                return Ok();
            }
            catch(Exception ex)
            {
                _logging.RegisterLog<IClientServices>(TipoLoggeo.Error, $"{MsgError} {MethodBase.GetCurrentMethod().Name}", $"{ErrorKey}{NameClass}", _clientServices, ex);
                return BadRequest(ex.Message);
            }
        }

    }
   
  

   
}
