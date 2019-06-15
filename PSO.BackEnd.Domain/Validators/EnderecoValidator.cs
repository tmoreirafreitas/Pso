using FluentValidation;
using PSO.BackEnd.Domain.Entities;
using System;

namespace PSO.BackEnd.Domain.Validators
{
    public class EnderecoValidator : AbstractValidator<Endereco>
    {
        public EnderecoValidator()
        {
            RuleFor(c => c).NotNull().OnAnyFailure(cl =>
            {
                throw new ArgumentNullException("O objeto endereço não pode ser nulo.");
            });

            RuleFor(e => e.Cep).NotEmpty().WithMessage("É necessário informar o CEP");
            RuleFor(e => e.Bairro).NotEmpty().WithMessage("É necessário informar o Bairro");
            RuleFor(e => e.Cidade).NotEmpty().WithMessage("É necessário informar a Cidade");
            RuleFor(e => e.Estado).NotEmpty().WithMessage("É necessário informar o Estado");
        }
    }
}
