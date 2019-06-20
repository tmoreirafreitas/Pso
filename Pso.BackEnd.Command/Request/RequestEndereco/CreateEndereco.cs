using Pso.BackEnd.Command.Request.Generic;
using PSO.BackEnd.Domain.Entities;

namespace Pso.BackEnd.Command.Request.RequestEndereco
{
    public class CreateEndereco : CreateCommand<Endereco>
    {
        public CreateEndereco(Endereco item) : base(item)
        {
        }
    }
}
