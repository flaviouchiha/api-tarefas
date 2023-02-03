using TaskApi.Models.DTO;
using FluentValidation;

namespace TaskApi.Validations
{
    public class AddTarefaValidation : AbstractValidator<TarefaAdicionarDto>, IValidator<TarefaAdicionarDto>
    {
        public AddTarefaValidation()
        {
            RuleFor(x => x.Descricao)
                .NotEmpty()
                    .WithMessage("A descrição deve deve ser preenchida")
                .MinimumLength(5)
                    .WithMessage("O tamanho mínimo da descrição é 5 caracteres")
                .MaximumLength(10)
                    .WithMessage("O tamanho máximo da descrição é 10 caracteres");
        }
    }
}