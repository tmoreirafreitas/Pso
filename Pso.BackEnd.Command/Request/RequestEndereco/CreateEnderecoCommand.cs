using Pso.BackEnd.Command.Request.Generic;
using PSO.BackEnd.Domain.Entities;

namespace Pso.BackEnd.Command.Request.RequestEndereco
{
    public class CreateEnderecoCommand : CreateCommand<Endereco>
    {
        public CreateEnderecoCommand(Endereco item) : base(item)
        {
        }
    }
}
