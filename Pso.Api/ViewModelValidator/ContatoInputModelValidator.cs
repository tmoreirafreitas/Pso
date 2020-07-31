using FluentValidation;
using Pso.Api.InputModel;

namespace Pso.Api.ViewModelValidator
{
    public class ContatoInputModelValidator : AbstractValidator<ContatoInputModel>
    {
        public ContatoInputModelValidator()
        {
            RuleFor(c => c.Telefone).NotEmpty().WithMessage("Por favor informe um número de telefone");
            RuleFor(c => c.Email).NotEmpty().WithMessage("Por favor informe um e-mail")
                .EmailAddress().WithMessage("O e-mail informado é inválido.");
            RuleFor(c => c.Nome).NotEmpty().WithMessage("Por favor informe o nome de um contato.");
        }
    }
}