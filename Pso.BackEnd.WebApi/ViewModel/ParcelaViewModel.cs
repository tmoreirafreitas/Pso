using System;

namespace Pso.BackEnd.WebApi.ViewModel
{
    public class ParcelaViewModel : EntityBaseViewModel
    {
        public int Numero { get; set; }
        public decimal Valor { get; set; }
        public DateTime DataVencimento { get; set; }
        public DateTime DataPagamento { get; set; }
        public bool Recebido { get; set; }
        public long FaturaId { get; set; }
        public FaturaViewModel Fatura { get; set; }
    }
}
