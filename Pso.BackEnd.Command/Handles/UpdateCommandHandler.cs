using MediatR;
using Pso.BackEnd.Command.Notifications;
using Pso.BackEnd.Command.Request.Generic;
using PSO.BackEnd.Domain.Entities;
using PSO.BackEnd.Domain.Interfaces.Repositories.Ef.Write;
using PSO.BackEnd.Domain.Interfaces.Repositories.UnitOfWork;
using System;
using System.Threading;
using System.Threading.Tasks;

namespace Pso.BackEnd.Command.Handles
{
    public class UpdateCommandHandler<T> : IRequestHandler<UpdateCommand<T>, bool> where T : Entity
    {
        protected readonly IWriteEfRepository<T> _repository;
        protected readonly IUnitOfWork _uow;
        protected readonly IMediator _mediator;
        public UpdateCommandHandler(IWriteEfRepository<T> repository, IUnitOfWork uow, IMediator mediator)
        {
            _repository = repository;
            _uow = uow;
            _mediator = mediator;
        }

        public async Task<bool> Handle(UpdateCommand<T> request, CancellationToken cancellationToken)
        {
            try
            {
                await _repository.UpdateAsync(i => i.Equals(request.Id), request.Item);
                var committed = _uow.Commit();
                if (committed)
                {
                    await _mediator.Publish(new UpdatedCommand<T>(request.Id, request.Item));
                }
                return committed;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
    }
}
