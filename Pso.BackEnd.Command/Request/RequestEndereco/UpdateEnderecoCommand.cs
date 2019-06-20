using Pso.BackEnd.Command.Request.Generic;
using PSO.BackEnd.Domain.Entities;

namespace Pso.BackEnd.Command.Request.RequestEndereco
{
    public class UpdateEnderecoCommand : UpdateCommand<Endereco>
    {
        public UpdateEnderecoCommand(long id, Endereco item) : base(id, item)
        {
        }
    }
}
