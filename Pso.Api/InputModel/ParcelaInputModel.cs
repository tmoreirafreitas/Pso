using System;

namespace Pso.Api.InputModel
{
    public class ParcelaInputModel
    {
        public int Numero { get; set; }
        public decimal Valor { get; set; }
        public DateTime DataVencimento { get; set; }
        public DateTime DataPagamento { get; set; }
        public bool Recebido { get; set; }
        public long FaturaId { get; set; }
        public FaturaInputModel Fatura { get; set; }
    }
}
