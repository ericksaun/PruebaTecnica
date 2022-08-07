using Microsoft.Extensions.DependencyInjection;

namespace Infrastructure.Mapper
{
    public static class ConfigAutoMapper
    {
        public static IServiceCollection? _services { get; set; }
        public static IServiceCollection configure(this IServiceCollection services)
        {
            _services = services;
            _services.AddAutoMapper(AppDomain.CurrentDomain.GetAssemblies());
            return services;
        }
    }
}