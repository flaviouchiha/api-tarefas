using FluentValidation;
using TaskApi.Data;
using TaskApi.Models.DTO;
using TaskApi.Services;
using TaskApi.Validations;

namespace TaskApi.Extensions
{
    public static class ServiceCollectionExtensions
    {
        public static IServiceCollection AddApiDependencies(this IServiceCollection services)
        {
            services.AddScoped<DataContext>();
            services.AddScoped<ITarefaService, TarefaService>();
            services.AddScoped<IValidator<TarefaAdicionarDto>, AddTarefaValidation>();

            return services;
        }
    }
}
