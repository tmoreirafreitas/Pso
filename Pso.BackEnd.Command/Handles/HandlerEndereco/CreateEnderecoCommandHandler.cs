using MediatR;
using PSO.BackEnd.Domain.Entities;
using PSO.BackEnd.Domain.Interfaces.Repositories.Ef.Write;
using PSO.BackEnd.Domain.Interfaces.Repositories.UnitOfWork;
using System;
using System.Collections.Generic;
using System.Text;

namespace Pso.BackEnd.Command.Handles.HandlerEndereco
{
    public class CreateEnderecoCommandHandler : CreateCommandHandler<Endereco>
    {
        public CreateEnderecoCommandHandler(IEnderecoWriteEfRepository repository, IUnitOfWork uow, IMediator mediator) : base(repository, uow, mediator)
        {
        }
    }
}
