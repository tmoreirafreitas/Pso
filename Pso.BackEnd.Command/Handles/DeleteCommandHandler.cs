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
        private readonly IWriteEfRepository<T> _repository;
        private readonly IUnitOfWork _uow;

        public DeleteCommandHandler(IWriteEfRepository<T> repository, IUnitOfWork uow)
        {
            _repository = repository;
            _uow = uow;
        }

        public async Task<bool> Handle(DeleteCommand<T> request, CancellationToken cancellationToken)
        {
            try
            {                
                await _repository.DeleteAsync(request.Id);
                return _uow.Commit();
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
    }
}
