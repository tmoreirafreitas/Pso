using FluentValidation;
using PSO.BackEnd.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Text;

namespace PSO.BackEnd.Domain.Validators
{
    public class ContatoValidator : AbstractValidator<Contato>
    {
        public ContatoValidator()
        {
            RuleFor(c => c).NotNull().OnAnyFailure(cont =>
            {
                throw new ArgumentNullException("O objeto telefone não pode ser nulo.");
            });

            RuleFor(c => c.Telefone).NotEmpty().WithMessage("É necessário informar o número do telefone");
            RuleFor(c=>c.Email).NotEmpty().WithMessage("É necessário informar o número do telefone/celular")
                .EmailAddress().WithMessage("O e-mail informado é inválido.");
            RuleFor(c => c.Nome).NotEmpty().WithMessage("É necessário informar o nome de um contato.");
        }
    }
}
