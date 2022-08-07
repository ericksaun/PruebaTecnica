using Infraestructure.LoggingService.Clases;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.IO;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;
using Microsoft.Extensions.Configuration;
using Serilog;
using Serilog.Configuration;
using Serilog.Core;
using Serilog.Events;
using Serilog.Formatting.Json;
using Serilog.Exceptions;
using Serilog.Exceptions.Core;

namespace Domain.LoggingService.Core
{
    public class Logging : ILogging
    {
        #region Constantes
        private const string PathLogKey = "SerilogLogging:Path";
        private const string LogLevelKey = "SerilogLogging:LogLevel:Default";
        private const string SourceEventLog = "SerilogLogging:EventLog:Source";
        private const string LogNameEventLog = "SerilogLogging:EventLog:LogName";
        private const string OutputTemplateKey = "SerilogLogging:EventLog:OutputTemplateKey";
        private const string LogEventVwrLevel = "SerilogLogging:EventLog:LogEventLevel";
        private const string KeyMap = "{Name}!";
        private const string KeyObjectPrint = "{@Object}";
        #endregion
        #region variables
        private readonly string _pathLog;
        private readonly string _logLevel;
        private readonly string _SourceEventLog;
        private readonly string _LogNameEventLog;
        private readonly string _OutputTemplateKey;
        private readonly string _LogEventVwrLevel;
        #endregion
        #region campos
        #endregion


        public Logger Logger { get; set; }

        public Logging(IConfiguration configuration)
        {
            IConfiguration _configuration = configuration;
            _pathLog = _configuration.GetSection(PathLogKey).Value;
            _logLevel = _configuration.GetSection(LogLevelKey).Value;
            _SourceEventLog = _configuration.GetSection(SourceEventLog).Value;
            _LogNameEventLog = _configuration.GetSection(LogNameEventLog).Value;
            _OutputTemplateKey = _configuration.GetSection(OutputTemplateKey).Value;
            _LogEventVwrLevel = _configuration.GetSection(LogEventVwrLevel).Value;
            InicializarLoggin();
        }
        /// <summary>
        /// Inizializa Looger
        /// </summary>
        public void InicializarLoggin()
        {
            if (!Directory.Exists(_pathLog))
            {
                Directory.CreateDirectory(_pathLog);
            }


            LogEventLevel Level = LoadTypeLogevent(_logLevel);
            LogEventLevel LevelEventvwr = LoadTypeLogevent(_LogEventVwrLevel);
            LoggingLevelSwitch levelSwitch = new LoggingLevelSwitch();
            levelSwitch.MinimumLevel = Level;
           
            Logger = new LoggerConfiguration()
                .MinimumLevel.ControlledBy(levelSwitch)
               .Enrich.WithExceptionDetails()
                .WriteTo.Map("Name", "Trace", (name, wt) => wt.Async(a => a.File(new JsonFormatter(),
                 !name.Contains("_") ?
                 $@"{_pathLog}\{name}\{name}.json" :
                 $@"{_pathLog}\{name.Split('_')[1]}\{name.Split('_')[0]}\{name}.json"
                 , shared: true, rollingInterval: RollingInterval.Day
                )))
               
                .CreateLogger();


        }
        /// <summary>
        /// Registra Log en Archivo
        /// </summary>
        /// <typeparam name="T">T</typeparam>
        /// <param name="tipo">tipo</param>
        /// <param name="Mensaje">Mensaje</param>
        /// <param name="PropertyForMapLog">PropertyForMapLog</param>
        /// <param name="exception">exception</param>
        #region HelperMethod
        public void RegisterLog<T>(TipoLoggeo tipo, string Mensaje, string PropertyForMapLog, Exception exception = null)
        {


            switch (tipo)
            {
                case TipoLoggeo.Information:
                    {

                        if (exception != null)
                        {
                            Logger.ForContext<T>().Information(exception, $"{Mensaje},{KeyMap}", PropertyForMapLog);
                        }
                        else
                        {
                            Logger.ForContext<T>().Information($"{Mensaje},{KeyMap}", PropertyForMapLog);
                        }
                        break;
                    }
                case TipoLoggeo.Error:
                    {

                        if (exception != null)
                        {
                            Logger.ForContext<T>().Error(exception, $"{Mensaje},{KeyMap}", PropertyForMapLog);
                        }
                        else
                        {
                            Logger.ForContext<T>().Error($"{Mensaje},{KeyMap} ", PropertyForMapLog);
                        }
                        break;
                    }
                case TipoLoggeo.Fatal:
                    {

                        if (exception != null)
                        {
                            Logger.ForContext<T>().Fatal(exception, $"{Mensaje},{KeyMap}", PropertyForMapLog);
                        }
                        else
                        {
                            Logger.ForContext<T>().Fatal($"{Mensaje},{KeyMap}", PropertyForMapLog);
                        }
                        break;
                    }
                case TipoLoggeo.Verbose:
                    {

                        if (exception != null)
                        {
                            Logger.ForContext<T>().Verbose(exception, $"{Mensaje},{KeyMap}", PropertyForMapLog);
                        }
                        else
                        {
                            Logger.ForContext<T>().Verbose($"{Mensaje},{KeyMap}", PropertyForMapLog);
                        }
                        break;
                    }
                case TipoLoggeo.Warning:
                    {

                        if (exception != null)
                        {
                            Logger.ForContext<T>().Warning(exception, $"{Mensaje},{KeyMap}", PropertyForMapLog);
                        }
                        else
                        {
                            Logger.ForContext<T>().Warning($"{Mensaje},{KeyMap}", PropertyForMapLog);
                        }
                        break;
                    }
                case TipoLoggeo.Debug:
                    {

                        if (exception != null)
                        {
                            Logger.ForContext<T>().Debug(exception, $"{Mensaje},{KeyMap}", PropertyForMapLog);
                        }
                        else
                        {
                            Logger.ForContext<T>().Debug($"{Mensaje},{KeyMap}", PropertyForMapLog);
                        }
                        break;
                    }
            }

        }
        /// <summary>
        /// Registra Log en Archivo
        /// </summary>
        /// <typeparam name="T">T</typeparam>
        /// <param name="tipo">tipo</param>
        /// <param name="Mensaje">Mensaje</param>
        /// <param name="PropertyForMapLog">PropertyForMapLog</param>
        /// <param name="Object">Object</param>
        /// <param name="exception">exception</param>
        public void RegisterLog<T>(TipoLoggeo tipo, string Mensaje, string PropertyForMapLog, T Object, Exception exception = null)
        {
            switch (tipo)
            {
                case TipoLoggeo.Information:
                    {

                        if (exception != null)
                        {
                            Logger.ForContext<T>().Information(exception, $"{Mensaje},{KeyMap} {Environment.NewLine} {KeyObjectPrint} ", PropertyForMapLog, Object);


                        }

                        else
                        {
                            Logger.ForContext<T>().Information($"{Mensaje},{KeyMap} {Environment.NewLine} {KeyObjectPrint} ", PropertyForMapLog, Object);
                        }
                        break;
                    }
                case TipoLoggeo.Error:
                    {

                        if (exception != null)
                        {
                            Logger.ForContext<T>().Error(exception, $"{Mensaje},{KeyMap} {Environment.NewLine} {KeyObjectPrint} ", PropertyForMapLog, Object);
                        }
                        else
                        {
                            Logger.ForContext<T>().Error($"{Mensaje},{KeyMap} {Environment.NewLine} {KeyObjectPrint} ", PropertyForMapLog, Object);
                        }
                        break;
                    }
                case TipoLoggeo.Fatal:
                    {

                        if (exception != null)
                        {
                            Logger.ForContext<T>().Fatal(exception, $"{Mensaje},{KeyMap} {Environment.NewLine} {KeyObjectPrint} ", PropertyForMapLog, Object);
                        }
                        else
                        {
                            Logger.ForContext<T>().Fatal($"{Mensaje},{KeyMap} {Environment.NewLine} {KeyObjectPrint} ", PropertyForMapLog, Object);
                        }
                        break;
                    }
                case TipoLoggeo.Verbose:
                    {

                        if (exception != null)
                        {
                            Logger.ForContext<T>().Verbose(exception, $"{Mensaje},{KeyMap} {Environment.NewLine} {KeyObjectPrint} ", PropertyForMapLog, Object);
                        }
                        else
                        {
                            Logger.ForContext<T>().Verbose($"{Mensaje},{KeyMap} {Environment.NewLine} {KeyObjectPrint} ", PropertyForMapLog, Object);
                        }
                        break;
                    }
                case TipoLoggeo.Warning:
                    {

                        if (exception != null)
                        {
                            Logger.ForContext<T>().Warning(exception, $"{Mensaje},{KeyMap} {Environment.NewLine} {KeyObjectPrint} ", PropertyForMapLog, Object);
                        }
                        else
                        {
                            Logger.ForContext<T>().Warning($"{Mensaje},{KeyMap} {Environment.NewLine} {KeyObjectPrint} ", PropertyForMapLog, Object);
                        }
                        break;
                    }
                case TipoLoggeo.Debug:
                    {

                        if (exception != null)
                        {
                            Logger.ForContext<T>().Debug(exception, $"{Mensaje},{KeyMap} {Environment.NewLine} {KeyObjectPrint} ", PropertyForMapLog, Object);
                        }
                        else
                        {
                            Logger.ForContext<T>().Debug($"{Mensaje},{KeyMap} {Environment.NewLine} {KeyObjectPrint} ", PropertyForMapLog, Object);
                        }
                        break;
                    }
            }
        }
        /// <summary>
        /// Registra Log en Archivo
        /// </summary>
        /// <param name="tipo">tipo</param>
        /// <param name="Mensaje">Mensaje</param>
        /// <param name="PropertyForMapLog">PropertyForMapLog</param>
        /// <param name="exception">exception</param>
        public void RegisterLog(TipoLoggeo tipo, string Mensaje, string PropertyForMapLog, Exception exception = null)
        {
            switch (tipo)
            {
                case TipoLoggeo.Information:
                    {

                        if (exception != null)
                        {
                            Logger.Information(exception, $"{Mensaje},{KeyMap}", PropertyForMapLog);
                        }
                        else
                        {
                            Logger.Information($"{Mensaje},{KeyMap}", PropertyForMapLog);
                        }
                        break;
                    }
                case TipoLoggeo.Error:
                    {

                        if (exception != null)
                        {
                            Logger.Error(exception, $"{Mensaje},{KeyMap}", PropertyForMapLog);
                        }
                        else
                        {
                            Logger.Error($"{Mensaje},{KeyMap}", PropertyForMapLog);
                        }
                        break;
                    }
                case TipoLoggeo.Fatal:
                    {

                        if (exception != null)
                        {
                            Logger.Fatal(exception, $"{Mensaje},{KeyMap}", PropertyForMapLog);
                        }
                        else
                        {
                            Logger.Fatal($"{Mensaje},{KeyMap}", PropertyForMapLog);
                        }
                        break;
                    }
                case TipoLoggeo.Verbose:
                    {

                        if (exception != null)
                        {
                            Logger.Verbose(exception, $"{Mensaje},{KeyMap} ", PropertyForMapLog);
                        }
                        else
                        {
                            Logger.Verbose($"{Mensaje},{KeyMap}", PropertyForMapLog);
                        }
                        break;
                    }
                case TipoLoggeo.Warning:
                    {

                        if (exception != null)
                        {
                            Logger.Warning(exception, $"{Mensaje},{KeyMap}", PropertyForMapLog);
                        }
                        else
                        {
                            Logger.Warning($"{Mensaje},{KeyMap}", PropertyForMapLog);
                        }
                        break;
                    }
                case TipoLoggeo.Debug:
                    {

                        if (exception != null)
                        {
                            Logger.Debug(exception, $"{Mensaje},{KeyMap}", PropertyForMapLog);
                        }
                        else
                        {
                            Logger.Debug($"{Mensaje},{KeyMap}", PropertyForMapLog);
                        }
                        break;
                    }
            }
        }

        /// <summary>
        /// Metodo que devuelve el nivel de log
        /// </summary>
        /// <param name="Type">Type</param>
        /// <returns></returns>
        private static LogEventLevel LoadTypeLogevent(string Type)
        {
            switch (Type)
            {
                case "Debug":
                    {
                        return LogEventLevel.Debug;

                    }
                case "Error":
                    {
                        return LogEventLevel.Error;

                    }
                case "Fatal":
                    {
                        return LogEventLevel.Fatal;

                    }
                case "Information":
                    {
                        return LogEventLevel.Information;

                    }
                case "Verbose":
                    {
                        return LogEventLevel.Verbose;

                    }
                case "Warning":
                    {
                        return LogEventLevel.Warning;

                    }
                default:
                    return LogEventLevel.Verbose;

            }


        }

        #endregion



    }
}
