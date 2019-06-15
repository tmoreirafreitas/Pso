using FluentValidation;
using PSO.BackEnd.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Text;

namespace PSO.BackEnd.Domain.Validators
{
    public class TelefoneValidator : AbstractValidator<Telefone>
    {
        public TelefoneValidator()
        {
            RuleFor(t => t).NotNull().OnAnyFailure(fat =>
            {
                throw new ArgumentNullException("O objeto telefone não pode ser nulo.");
            });

            RuleFor(t => t.Ddd).NotEmpty().WithMessage("É necessário informar o número do DDD ex:21");
            RuleFor(t => t.Numero).NotEmpty().WithMessage("É necessário informar o número do telefone/celular");
        }
    }
}
