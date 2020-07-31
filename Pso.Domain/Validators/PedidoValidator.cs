using System;
using FluentValidation;
using Pso.Domain.Entities;

namespace Pso.Domain.Validators
{
    public class PedidoValidator : AbstractValidator<Pedido>
    {
        public PedidoValidator()
        {
            RuleFor(p => p).NotNull().OnAnyFailure(ped =>
            {
                throw new ArgumentNullException("O objeto pedido não pode ser nulo.");
            });

            RuleFor(p => p.Preco).GreaterThan(0).WithMessage("O preço informado tem que ter valor maior que 0.");
            RuleFor(p => p.Servico).NotEmpty().WithMessage("É necessário descrever o serviço prestado.");
            RuleFor(p => p.DataSolicitacao)
                .NotNull().WithMessage("É necessário informar a data de solicitação")
                .LessThanOrEqualTo(DateTime.Now.AddDays(1)).WithMessage("A data de solicitação informada deve ser menor ou igual a data de hoje.")
                .LessThanOrEqualTo(p => p.DataEntrega).WithMessage("A data de solicitação deve ser menor ou igual a data de entrega.");

            RuleFor(p => p.DataEntrega)
                .NotNull().WithMessage("É necessário informar a data de entrega")
                .GreaterThanOrEqualTo(p => p.DataSolicitacao).WithMessage("A data de entrega deve ser maior ou igual a data de solicitação.");
        }
    }
}
