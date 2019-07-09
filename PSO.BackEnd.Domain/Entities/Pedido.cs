using PSO.BackEnd.Domain.Validators;
using System;
using System.Collections.Generic;

namespace PSO.BackEnd.Domain.Entities
{
    public class Pedido : Entity
    {
        public string Servico { get; private set; }
        public string Obs { get; private set; }
        public string Medico { get; private set; }
        public DateTime DataEntrega { get; private set; }
        public DateTime DataSolicitacao { get; private set; }
        public long ClienteId { get; private set; }
        public long FaturaId { get; private set; }
        public Cliente Cliente { get; set; }
        public Fatura Fatura { get; set; }
        //public virtual ApplicationUser ApplicationUser { get; set; }
        public ICollection<PedidoOculos> PedidosOculos { get; private set; }        
        public decimal Preco { get; private set; }

        public Pedido(string servico, string medico, decimal preco, DateTime dataEntrega, DateTime dataSolicitacao,
            long clienteId, long faturaId, string obs)
        {
            Servico = servico;
            Obs = obs;
            Medico = medico;
            DataEntrega = dataEntrega;
            DataSolicitacao = dataSolicitacao;
            ClienteId = clienteId;
            FaturaId = faturaId;
            PedidosOculos = new List<PedidoOculos>();
            Preco = preco;
            Validate(this, new PedidoValidator());
        }
    }
}
