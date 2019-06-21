using Pso.BackEnd.Command.Request.Generic;
using PSO.BackEnd.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Text;

namespace Pso.BackEnd.Command.Request.RequestEndereco
{
    public class DeleteEnderecoCommand : DeleteCommand<Endereco>
    {
        public DeleteEnderecoCommand(long id, Endereco item) : base(id, item)
        {
        }
    }
}
