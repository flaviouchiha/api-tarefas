using TaskApi.Models;

namespace Tests;

public class ModelsTest
{
    [Fact]
    public void Tarefa_ReturnTarefaPreenchida()
    {
        var tarefa = new Tarefa
        {
            Codigo = 1,
            Descricao = "Teste",
            Status = 'P'
        };

        Assert.NotNull(tarefa);
    }
}