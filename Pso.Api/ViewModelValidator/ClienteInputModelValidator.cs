using FluentValidation;
using Pso.Api.InputModel;
using Pso.Domain.Validators.CustomValidator;
using System;

namespace Pso.Api.ViewModelValidator
{
    public class ClienteInputModelValidator : AbstractValidator<ClienteInputModel>
    {
        public ClienteInputModelValidator()
        {
            RuleFor(c => c.Cpf)
                .NotEmpty()
                .IsValidCpf()
                .WithMessage("Por favor informe o CPF.");

            RuleFor(c => c.Nascimento)
                .NotEqual(DateTime.MinValue)
                .NotNull()
                .WithMessage("É necessário informar a data de nascimento.");

            RuleFor(c => DateTime.Now.Year - c.Nascimento.Year)
                .InclusiveBetween(0, 200);

            RuleFor(c => c.Nascimento.AddYears(-18).Year)
                .GreaterThanOrEqualTo(18)
                .WithMessage("Não é possível cadastrar um cliente menor de idade");

            RuleFor(c => c.Nome)
                .NotEmpty()
                .WithMessage("Por favor informe o nome.");

            RuleFor(c => c.Rg)
                .NotEmpty()
                .WithMessage("Por favor informe o RG.");

            RuleFor(c => c.Endereco)
                .NotNull()
                .WithMessage("Por favor informe o endereço a ser cadastrado.");

            RuleForEach(c => c.Contatos)
                .NotEmpty()
                .WithMessage("Por favor informe pelo menos um contato.");
        }
    }
}