using Application.Module;
using AutoMapper;
using Domain.LoggingService.Core;
using Domain.PruebaTecnica.Interfaces;
using Infrastructure.DataAccess.EFCore.Repositories;
using Infrastructure.DataAccess.EFCore.UnitOfWork;
using Microsoft.Extensions.DependencyInjection;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;


namespace Infrastructure.Crosslayer.IOC.IOC
{
    public static class ConfigurationIoC
    {


        public static IServiceCollection? _services { get; set; }
        public static IServiceCollection AddDependency(this IServiceCollection services)
        {
            _services = services;
            services.AddTransient(typeof(IGenericRepository<>), typeof(GenericRepository<>));
            services.AddTransient<IClientRepository, ClientRepository>();
            services.AddTransient<IAccountsRepository, AccountsRepository>();
            services.AddTransient<IMovementsRepository, MovementsRepository>();
            services.AddTransient<IUnitOfWork, UnitOfWork>();
            services.AddTransient<IClientServices, ClientServices>();
            services.AddTransient<IAccountsServices, AccountsServices>();
            services.AddTransient<ILogging, Logging>();
            services.AddTransient<IMovementsServices, MovementsServices>();
          
            return services;
        }

    }
}
