using FluentValidation;
using Pso.Api.InputModel;

namespace Pso.Api.ViewModelValidator
{
    public class EnderecoInputModelValidator : AbstractValidator<EnderecoInputModel>
    {
        public EnderecoInputModelValidator()
        {
            RuleFor(e => e.Cep).NotEmpty().WithMessage("Por favor informe o CEP");
            RuleFor(e => e.Logradouro).NotEmpty().WithMessage("Por favor informe o Logradouro");
            RuleFor(e => e.Bairro).NotEmpty().WithMessage("Por favor informe o Bairro");
            RuleFor(e => e.Cidade).NotEmpty().WithMessage("Por favor informe a Cidade");
            RuleFor(e => e.Estado).NotEmpty().WithMessage("Por favor informe o Estado");
        }
    }
}