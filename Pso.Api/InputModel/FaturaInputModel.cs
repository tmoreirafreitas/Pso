using System;
using System.Collections.Generic;
using Pso.Domain.Enum;

namespace Pso.Api.InputModel
{
    public class FaturaInputModel
    {
        public decimal Valor { get; set; }
        public decimal Total { get; set; }
        public decimal Sinal { get; set; }
        public bool IsPaga { get; set; }
        public DateTime DataPagamento { get; set; }
        public int NumeroParcelas { get; set; }
        public FormaPagamento FormaPagamento { get; set; }
        public PedidoInputModel Pedido { get; set; }
        public ICollection<ParcelaInputModel> Parcelas { get; set; }
    }
}
