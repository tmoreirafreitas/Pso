using MediatR;
using PSO.BackEnd.Domain.Entities;
using PSO.BackEnd.Domain.Interfaces.Repositories.Ef.Write;
using PSO.BackEnd.Domain.Interfaces.Repositories.UnitOfWork;

namespace Pso.BackEnd.Command.Handles.HandlerPedidoOculos
{
    public class CreatePedidoOculosCommandHandler : CreateCommandHandler<PedidoOculos>
    {
        public CreatePedidoOculosCommandHandler(IPedidoOculosWriteEfRepository repository, IUnitOfWork uow, IMediator mediator) 
            : base(repository, uow, mediator)
        {
        }
    }
}
