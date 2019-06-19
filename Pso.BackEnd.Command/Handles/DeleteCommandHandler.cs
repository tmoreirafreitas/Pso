using MediatR;
using Pso.BackEnd.Command.Request;
using PSO.BackEnd.Domain.Entities;
using PSO.BackEnd.Domain.Interfaces.Repositories.Relational.Write;
using PSO.BackEnd.Domain.Interfaces.Repositories.UnitOfWork;
using System;
using System.Threading;
using System.Threading.Tasks;

namespace Pso.BackEnd.Command.Handles
{
    public class DeleteCommandHandler<T> : IRequestHandler<DeleteCommand<T>, bool> where T : Entity, new()
    {
        private readonly IWriteRelationalRepository<T> _repository;
        private readonly IUnitOfWork _uow;

        public DeleteCommandHandler(IWriteRelationalRepository<T> repository, IUnitOfWork uow)
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
