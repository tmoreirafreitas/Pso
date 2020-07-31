using System;

namespace Pso.Api.ViewModel
{
    public class ParcelaViewModel : EntityBaseViewModel
    {
        public int Numero { get; set; }
        public decimal Valor { get; set; }
        public DateTime DataVencimento { get; set; }
        public DateTime DataPagamento { get; set; }
        public bool Recebido { get; set; }
        public long FaturaId { get; set; }
    }
}