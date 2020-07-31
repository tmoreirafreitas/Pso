using Pso.Domain.Core.Contato.Commands.Cadastrar;
using Pso.Domain.Core.Endereco.Commands.Cadastrar;
using Pso.Domain.Core.Pedido.Commands.Cadastrar;
using Pso.Domain.Core.Validators;
using Pso.Domain.Enum;
using System;
using System.Collections.Generic;

namespace Pso.Domain.Core.Cliente.Commands.Cadastrar
{
    public class CadastrarClienteCommand : Command<Entities.Cliente>
    {
        public long Id { get; set; }
        public string Nome { get; private set; }
        public string Rg { get; private set; }
        public string Cpf { get; private set; }
        public string Filiacao { get; private set; }
        public bool IsSpc { get; private set; }
        public DateTime Nascimento { get; private set; }
        public CadastrarEnderecoCommand Endereco { get; set; }
        public SexoType Sexo { get; private set; }
        public ICollection<CadastrarContatoCommand> Contatos { get; private set; }
        public ICollection<CadastrarPedidoCommand> Pedidos { get; private set; }

        public CadastrarClienteCommand(string nome, string rg, string cpf, string filiacao, bool isSPC, DateTime nascimento, SexoType sexo)
        {
            Nome = nome;
            Rg = rg;
            Cpf = cpf;
            Filiacao = filiacao;
            IsSpc = isSPC;
            Nascimento = nascimento;
            Contatos = new List<CadastrarContatoCommand>();
            Pedidos = new List<CadastrarPedidoCommand>();
            Sexo = sexo;
            Validate(this, new CadastrarClienteCommandValidator());
        }
    }
}
