using MediatR;
using PSO.BackEnd.Domain.Entities;
using PSO.BackEnd.Domain.Interfaces.Repositories.Ef.Write;
using PSO.BackEnd.Domain.Interfaces.Repositories.UnitOfWork;

namespace Pso.BackEnd.Command.Handles.HandlerPedidoOculos
{
    public class UpdatePedidoOculosCommandHandler : UpdateCommandHandler<PedidoOculos>
    {
        public UpdatePedidoOculosCommandHandler(IPedidoOculosWriteEfRepository repository, IUnitOfWork uow, IMediator mediator) 
            : base(repository, uow, mediator)
        {
        }
    }
}
