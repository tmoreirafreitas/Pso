using Pso.BackEnd.Command.Request.Generic;
using PSO.BackEnd.Domain.Entities;

namespace Pso.BackEnd.Command.Request.RequestEndereco
{
    public class DeleteEnderecoCommand : DeleteCommand<Endereco>
    {
        public DeleteEnderecoCommand(long id) : base(id)
        {

        }

        public DeleteEnderecoCommand(long id, Endereco item) : base(id, item)
        {
        }
    }
}
