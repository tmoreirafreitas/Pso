using PSO.BackEnd.Domain.Entities;
using PSO.BackEnd.Domain.Interfaces.Repositories.Ef.Write;
using PSO.BackEnd.Domain.Interfaces.Repositories.UnitOfWork;
using System;
using System.Collections.Generic;
using System.Text;

namespace Pso.BackEnd.Command.Handles.HandlerLente
{
    public class DeleteLenteCommandHandler : DeleteCommandHandler<Lente>
    {
        public DeleteLenteCommandHandler(ILenteWriteEfRepository repository, IUnitOfWork uow) : base(repository, uow)
        {
        }
    }
}
