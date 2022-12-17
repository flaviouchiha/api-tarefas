using TaskApi.Data;
using TaskApi.Services;

namespace TaskApi.Extensions
{
    public static class ServiceCollectionExtensions
    {
        public static void AddApiDependencies(this IServiceCollection services)
        {
            services.AddScoped<DataContext>();
            services.AddScoped<ITarefaService, TarefaService>();
        }
    }
}
