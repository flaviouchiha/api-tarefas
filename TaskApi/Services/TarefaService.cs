using FluentValidation;
using Microsoft.EntityFrameworkCore;
using TaskApi.Data;
using TaskApi.Models;
using TaskApi.Models.DTO;

namespace TaskApi.Services
{
    public class TarefaService : ITarefaService
    {
        private readonly DataContext _dataContext;
        private readonly IValidator<TarefaAdicionarDto> _validator;

        public TarefaService(DataContext dataContext, IValidator<TarefaAdicionarDto> validator)
        {
            _dataContext = dataContext;
            _validator = validator;
        }

        public async Task<Tarefa> Adicionar(TarefaAdicionarDto tarefaDto)
        {
            var validationResult = await _validator.ValidateAsync(tarefaDto);

            var errors = string.Join(" | ", validationResult.Errors);

            if (!validationResult.IsValid)
                throw new Exception(errors);

            var tarefa = new Tarefa
            {
                Descricao = tarefaDto.Descricao,
                Status = 'P',
            };

            _dataContext.Tarefas.Add(tarefa);

            await _dataContext.SaveChangesAsync();

            return tarefa;
        }

        public async Task Editar(Tarefa tarefaEditada)
        {
            var tarefa = _dataContext.Tarefas
                .Where(x => x.Codigo == tarefaEditada.Codigo)
                .FirstOrDefault();

            if (tarefa is null)
                throw new ArgumentException("Tarefa não localizada");

            tarefa.Descricao = tarefaEditada.Descricao;
            tarefa.Status = tarefaEditada.Status;

            if (!TarefaValida(tarefa))
                throw new ArgumentException("Status ou Descrição inválida");

            await _dataContext.SaveChangesAsync();
        }

        private static bool TarefaValida(Tarefa tarefa)
        {
            char[] statusValidos = new char[] { 'P', 'C' };

            if (statusValidos.Contains(tarefa.Status) && !string.IsNullOrEmpty(tarefa.Descricao))
                return true;

            return false;
        }

        public async Task Deletar(int codigo)
        {
            var tarefa = _dataContext.Tarefas
                .Where(x => x.Codigo == codigo)
                .FirstOrDefault();

            if (tarefa is null)
                throw new ArgumentException("Tarefa não localizada");

            _dataContext.Remove(tarefa);

            await _dataContext.SaveChangesAsync();
        }

        public Tarefa ObterPorCodigo(int codigo)
        {
            var result = _dataContext.Tarefas
                .Where(x => x.Codigo == codigo)
                .FirstOrDefault();

            return result;
        }

        public IEnumerable<Tarefa> ObterTodos()
        {
            var result = _dataContext.Tarefas
                .AsNoTracking()
                .OrderBy(x => x.Codigo)
                .AsEnumerable();

            return result;
        }
    }
}
