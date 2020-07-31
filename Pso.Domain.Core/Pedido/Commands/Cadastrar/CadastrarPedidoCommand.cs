using System;
using System.Collections.Generic;
using Pso.Domain.Core.Cliente.Commands.Cadastrar;
using Pso.Domain.Core.Fatura.Commands.Cadastrar;
using Pso.Domain.Core.Validators;

namespace Pso.Domain.Core.Pedido.Commands.Cadastrar
{
    public class CadastrarPedidoCommand : Command<Entities.Pedido>
    {
        public string Servico { get; private set; }
        public string Obs { get; private set; }
        public string Medico { get; private set; }
        public DateTime DataEntrega { get; private set; }
        public DateTime DataSolicitacao { get; private set; }
        public long ClienteId { get; private set; }
        public long FaturaId { get; private set; }
        public CadastrarClienteCommand Cliente { get; set; }
        public CadastrarFaturaCommand Fatura { get; set; }
        public ICollection<CadastrarPedidoOculosCommand> PedidosOculos { get; private set; }
        public decimal Preco { get; private set; }

        public CadastrarPedidoCommand(string servico, string medico, decimal preco, DateTime dataEntrega, DateTime dataSolicitacao,
            long clienteId, long faturaId, string obs)
        {
            Servico = servico;
            Obs = obs;
            Medico = medico;
            DataEntrega = dataEntrega;
            DataSolicitacao = dataSolicitacao;
            ClienteId = clienteId;
            FaturaId = faturaId;
            PedidosOculos = new List<CadastrarPedidoOculosCommand>();
            Preco = preco;
            Validate(this, new CadastrarPedidoCommandValidator());
        }
    }
}