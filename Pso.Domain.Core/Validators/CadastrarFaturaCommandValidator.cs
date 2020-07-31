using FluentValidation;
using Pso.Domain.Core.Fatura.Commands.Cadastrar;
using System;

namespace Pso.Domain.Core.Validators
{
    public class CadastrarFaturaCommandValidator : AbstractValidator<CadastrarFaturaCommand>
    {
        public CadastrarFaturaCommandValidator()
        {
            RuleFor(f => f).NotNull().OnAnyFailure(fat => throw new ArgumentNullException($"O objeto fatura não pode ser nulo."));
            RuleFor(fat => fat.FormaPagamento).NotNull().WithMessage("É necessário informar a forma de pagamento.");
            RuleFor(fat => fat.Total).NotEqual(0).WithMessage("É necessário informar o total da fatura.");
        }
    }
}