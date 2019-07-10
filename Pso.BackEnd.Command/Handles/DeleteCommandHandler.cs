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
    public class DeleteCommandHandler<T> : IRequestHandler<DeleteCommand<T>, bool> where T : Entity
    {
        protected readonly IWriteEfRepository<T> _repository;
        protected readonly IUnitOfWork _uow;
        protected readonly IMediator _mediator;

        public DeleteCommandHandler(IWriteEfRepository<T> repository, IUnitOfWork uow, IMediator mediator)
        {
            _repository = repository;
            _uow = uow;
            _mediator = mediator;
        }

        public Task<bool> Handle(DeleteCommand<T> request, CancellationToken cancellationToken)
        {
            var committed = DeleteCommandItem(request);
            if (committed)
            {
                _mediator.Publish(new DeleteCommand<T>(request.Id, request.Item));
            }
            return Task.FromResult(committed);
        }

        protected bool DeleteCommandItem(DeleteCommand<T> request)
        {
            try
            {
                _repository.Delete(request.Id);
                var committed = _uow.Commit();
                return committed;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
    }
}
