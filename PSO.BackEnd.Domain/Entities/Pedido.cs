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
        public Cliente Cliente { get; set; }
        //public virtual ApplicationUser ApplicationUser { get; set; }
        public IEnumerable<Oculos> Oculos { get; private set; }
        public Fatura Fatura { get; set; }
        public decimal Preco { get; private set; }

        public Pedido(string servico, string medico, decimal preco, DateTime dataEntrega, DateTime dataSolicitacao,
            Cliente cliente, Fatura fatura, string obs)
        {
            Servico = servico;
            Obs = obs;
            Medico = medico;
            DataEntrega = dataEntrega;
            DataSolicitacao = dataSolicitacao;
            Cliente = cliente;
            Oculos = new List<Oculos>();
            Fatura = fatura;
            Preco = preco;
            Validate(this, new PedidoValidator());
        }
    }
}
