using FluentValidation;
using Pso.Domain.Core.Contato.Commands.Cadastrar;
using System;

namespace Pso.Domain.Core.Validators
{
    public class CadastrarContatoCommandValidator : AbstractValidator<CadastrarContatoCommand>
    {
        public CadastrarContatoCommandValidator()
        {
            RuleFor(c => c).NotNull().OnAnyFailure(cont => throw new ArgumentNullException($"O objeto telefone não pode ser nulo."));
            RuleFor(c => c.Telefone).NotEmpty().WithMessage("É necessário informar o número do telefone");
            RuleFor(c => c.Email).NotEmpty().WithMessage("É necessário informar o número do telefone/celular")
                .EmailAddress().WithMessage("O e-mail informado é inválido.");
            RuleFor(c => c.Nome).NotEmpty().WithMessage("É necessário informar o nome de um contato.");
        }
    }
}