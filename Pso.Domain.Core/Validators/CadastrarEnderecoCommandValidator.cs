using FluentValidation;
using Pso.Domain.Core.Endereco.Commands.Cadastrar;
using System;

namespace Pso.Domain.Core.Validators
{
    public class CadastrarEnderecoCommandValidator : AbstractValidator<CadastrarEnderecoCommand>
    {
        public CadastrarEnderecoCommandValidator()
        {
            RuleFor(c => c).NotNull().OnAnyFailure(cl => throw new ArgumentNullException($"O objeto endereço não pode ser nulo."));
            RuleFor(e => e.Cep).NotEmpty().WithMessage("É necessário informar o CEP");
            RuleFor(e => e.Bairro).NotEmpty().WithMessage("É necessário informar o Bairro");
            RuleFor(e => e.Cidade).NotEmpty().WithMessage("É necessário informar a Cidade");
            RuleFor(e => e.Estado).NotEmpty().WithMessage("É necessário informar o Estado");
        }
    }
}