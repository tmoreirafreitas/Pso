using System;
using System.Collections.Generic;

namespace Pso.Api.InputModel
{
    public class PedidoInputModel
    {
        public string Servico { get; set; }
        public string Obs { get; set; }
        public string Medico { get; set; }
        public DateTime DataEntrega { get; set; }
        public DateTime DataSolicitacao { get; set; }
        public long ClienteId { get; set; }
        public ClienteInputModel Cliente { get; set; }
        public ICollection<PedidoOculosInputModel> PedidosOculos { get; set; }
        public FaturaInputModel Fatura { get; set; }
        public decimal Preco { get; set; }
    }
}
