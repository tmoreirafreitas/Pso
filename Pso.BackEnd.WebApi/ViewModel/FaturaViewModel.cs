using PSO.BackEnd.Domain.Enum;
using System;
using System.Collections.Generic;

namespace Pso.BackEnd.WebApi.ViewModel
{
    public class FaturaViewModel : EntityBaseViewModel
    {
        public decimal Valor { get; set; }
        public decimal Total { get; set; }
        public decimal Sinal { get; set; }
        public bool IsPaga { get; set; }
        public DateTime DataPagamento { get; set; }
        public int NumeroParcelas { get; set; }
        public FormaPagamento FormaPagamento { get; set; }
        public long PedidoId { get; set; }
        public PedidoViewModel Pedido { get; set; }
        public ICollection<ParcelaViewModel> Parcelas { get; set; }
    }
}
