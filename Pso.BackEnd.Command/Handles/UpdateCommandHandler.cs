using MediatR;
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

        public virtual Task<bool> Handle(UpdateCommand<T> request, CancellationToken cancellationToken)
        {
            var committed = UpdateCommandItem(request).ConfigureAwait(false).GetAwaiter().GetResult();
            if (committed)
                _mediator.Publish(request);
            return Task.FromResult(committed);
        }

        protected Task<bool> UpdateCommandItem(UpdateCommand<T> updateCommand)
        {
            try
            {
                _repository.Update(updateCommand.Item);
                var committed = _uow.Commit();
                return Task.FromResult(committed);
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
    }
}
