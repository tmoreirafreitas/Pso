using System.Threading;
using System.Threading.Tasks;
using MediatR;
using Pso.BackEnd.Command.Request.Generic;
using PSO.BackEnd.Domain.Entities;
using PSO.BackEnd.Domain.Interfaces.Repositories.Ef.Write;
using PSO.BackEnd.Domain.Interfaces.Repositories.UnitOfWork;

namespace Pso.BackEnd.Command.Handles.HandlerParcela
{
    public class UpdateParcelaCommandHandler : UpdateCommandHandler<Parcela>
    {
        public UpdateParcelaCommandHandler(IParcelaWriteEfRepository repository, IUnitOfWork uow, IMediator mediator) : base(repository, uow, mediator)
        {
        }
    }
}
