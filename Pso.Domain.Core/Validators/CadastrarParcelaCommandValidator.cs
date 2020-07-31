using System;
using FluentValidation;
using Pso.Domain.Core.Parcela.Commands.Cadastrar;

namespace Pso.Domain.Core.Validators
{
    public class CadastrarParcelaCommandValidator : AbstractValidator<CadastrarParcelaCommand>
    {
        public CadastrarParcelaCommandValidator()
        {
            RuleFor(p => p).NotNull().OnAnyFailure(par => throw new ArgumentNullException($"O objeto parcela não pode ser nulo."));
            RuleFor(p => p.Valor).GreaterThanOrEqualTo(0).WithMessage("Valores negativos não são permitidos");
            RuleFor(p => p.Numero).GreaterThanOrEqualTo(0).WithMessage("O número da parcela tem que ser maior que 0.");
            RuleFor(p => p.DataVencimento).NotNull().WithMessage("É necessário informa a data de vencimento da parcela.");           
        }
    }
}
