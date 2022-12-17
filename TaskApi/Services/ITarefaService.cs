using TaskApi.Models;
using TaskApi.Models.DTO;

namespace TaskApi.Services
{
    public interface ITarefaService
    {
        Task<Tarefa> Adicionar(TarefaAdicionarDto tarefa);
        Task Deletar(int codigo);
        Task Editar(Tarefa tarefaEditar);
        Tarefa ObterPorCodigo(int codigo);
        IEnumerable<Tarefa> ObterTodos();
    }
}
