using System;

namespace Pso.Api.ViewModel
{
    public class PedidoViewModel : EntityBaseViewModel
    {
        public string Servico { get; set; }
        public string Obs { get; set; }
        public string Medico { get; set; }
        public DateTime DataEntrega { get; set; }
        public DateTime DataSolicitacao { get; set; }
        public long ClienteId { get; set; }
        public long FaturaId { get; set; }
        public decimal Preco { get; set; }
    }
}