using FluentValidation;
using PSO.BackEnd.Domain.Entities;
using System;

namespace PSO.BackEnd.Domain.Validators
{
    public class ParcelaValidator : AbstractValidator<Parcela>
    {
        public ParcelaValidator()
        {
            RuleFor(p => p).NotNull().OnAnyFailure(par =>
            {
                throw new ArgumentNullException("O objeto parcela não pode ser nulo.");
            });

            RuleFor(p => p.Valor).GreaterThanOrEqualTo(0).WithMessage("Valores negativos não são permitidos");
            RuleFor(p => p.Numero).GreaterThanOrEqualTo(0).WithMessage("O número da parcela tem que ser maior que 0.");
            RuleFor(p => p.DataVencimento).NotNull().WithMessage("É necessário informa a data de vencimento da parcela.");           
        }
    }
}
