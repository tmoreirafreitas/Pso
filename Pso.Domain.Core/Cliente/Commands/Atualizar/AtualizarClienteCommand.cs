using System;
using Pso.Domain.Core.Cliente.Commands.Cadastrar;
using Pso.Domain.Enum;

namespace Pso.Domain.Core.Cliente.Commands.Atualizar
{
    public class AtualizarClienteCommand : CadastrarClienteCommand
    {
        public AtualizarClienteCommand(string nome, string rg, string cpf, string filiacao, bool isSPC, DateTime nascimento, SexoType sexo) : base(nome, rg, cpf, filiacao, isSPC, nascimento, sexo)
        {
        }
    }
}