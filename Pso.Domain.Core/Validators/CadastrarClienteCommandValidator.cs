using System;
using FluentValidation;
using Pso.Domain.Core.Cliente.Commands.Cadastrar;

namespace Pso.Domain.Core.Validators
{
    public class CadastrarClienteCommandValidator : AbstractValidator<CadastrarClienteCommand>
    {
        public CadastrarClienteCommandValidator()
        {
            RuleFor(c => c).NotNull().OnAnyFailure(cl =>
            {
                throw new ArgumentNullException("O objeto cliente não pode ser nulo.");
            });

            RuleFor(c => c.Cpf).NotEmpty().WithMessage("É necessário informar o CPF");
            RuleFor(c => c.Nascimento).NotNull().WithMessage("É necessário informar a data de nascimento");
            RuleFor(c => c.Nome).NotEmpty().WithMessage("É necessário informar o nome");
            RuleFor(c => c.Rg).NotEmpty().WithMessage("É necessário informar o RG");
        }
    }
}