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
    public class CreateCommandHandler<T> : IRequestHandler<CreateCommand<T>, bool> where T : Entity
    {
        protected readonly IWriteEfRepository<T> _repository;
        protected readonly IUnitOfWork _uow;
        protected readonly IMediator _mediator;

        public CreateCommandHandler(IWriteEfRepository<T> repository, IUnitOfWork uow, IMediator mediator)
        {
            _repository = repository;
            _uow = uow;
            _mediator = mediator;
        }

        public virtual Task<bool> Handle(CreateCommand<T> request, CancellationToken cancellationToken)
        {
            var committed = CreateCommandItem(request);
            if(committed)
                _mediator.Publish(request);
            return Task.FromResult(committed);
        }

        protected bool CreateCommandItem(CreateCommand<T> createCommand)
        {
            try
            {
                _repository.Add(createCommand.Item);
                return _uow.Commit();
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
    }
}
