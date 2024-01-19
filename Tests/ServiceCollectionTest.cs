using Microsoft.Extensions.DependencyInjection;
using TaskApi.Extensions;
using TaskApi.Services;

namespace Tests
{
    public class ServiceCollectionTest
    {
        [Fact]
        public void ServiceCollection_ValidarDI_ReturnITarefaService()
        {
            IServiceCollection services = new ServiceCollection();

            IServiceProvider serviceProvider = services
                .AddApiDependencies()
                .BuildServiceProvider();

            var tarefaService = serviceProvider.GetService<ITarefaService>();

            Assert.NotNull(tarefaService);
        }
    }
}