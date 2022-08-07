using Infrastructure.DataAccess.EFCore;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;

namespace Infrastructure.Data
{
    public static class DataConfiguration
    {
        public static IServiceCollection? _services { get; set; }
        private static readonly string csPruebaTecnicabddKey = "ConnectionStrings:DefaultConnection";
      

        public static IServiceCollection configure(this IServiceCollection services)
        {
            _services = services;
            _services.AddDbContext<ApplicationContext>(options => 
            {
                options.UseSqlServer(SettingsConfigHelper.AppSetting(csPruebaTecnicabddKey),
                    b => b.MigrationsAssembly(typeof(ApplicationContext).Assembly.FullName)
                    );
            });

            return _services;
        }

        
    }
}