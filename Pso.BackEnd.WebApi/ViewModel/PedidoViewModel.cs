using System;
using System.Collections.Generic;

namespace Pso.BackEnd.WebApi.ViewModel
{
    public class PedidoViewModel : EntityBaseViewModel
    {
        public string Servico { get; set; }
        public string Obs { get; set; }
        public string Medico { get; set; }
        public DateTime DataEntrega { get; set; }
        public DateTime DataSolicitacao { get; set; }
        public long ClienteId { get; set; }
        public ClienteViewModel Cliente { get; set; }
        public ICollection<PedidoOculosViewModel> PedidosOculos { get; set; }
        public FaturaViewModel Fatura { get; set; }
        public decimal Preco { get; set; }
    }
}
