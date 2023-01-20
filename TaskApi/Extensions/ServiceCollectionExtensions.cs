using TaskApi.Data;
using TaskApi.Services;

namespace TaskApi.Extensions
{
    public static class ServiceCollectionExtensions
    {
        public static IServiceCollection AddApiDependencies(this IServiceCollection services)
        {
            services.AddScoped<DataContext>();
            services.AddScoped<ITarefaService, TarefaService>();

            return services;
        }
    }
}
