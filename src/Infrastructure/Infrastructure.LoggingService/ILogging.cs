using Infraestructure.LoggingService.Clases;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Serilog.Core;

namespace Domain.LoggingService.Core
{
    public interface ILogging
    {
        void RegisterLog<T>(TipoLoggeo tipo, string Mensaje, string PropertyForMapLog, Exception exception = null);
        void RegisterLog<T>(TipoLoggeo tipo, string Mensaje, string PropertyForMapLog, T Object, Exception exception = null);
        void RegisterLog(TipoLoggeo tipo, string Mensaje, string PropertyForMapLog, Exception exception = null);

    }
}
