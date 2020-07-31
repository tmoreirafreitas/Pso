using System;
using Pso.Domain.Validators;

namespace Pso.Domain.Entities
{
    public class Parcela : Entity
    {
        public int Numero { get; private set; }
        public decimal Valor { get; private set; }
        public DateTime DataVencimento { get; private set; }
        public DateTime DataPagamento { get; private set; }
        public bool Recebido { get; private set; }
        public long FaturaId { get; private set; }
        public Fatura Fatura { get; private set; }
        public Parcela(int numero, decimal valor, DateTime dataVencimento, DateTime dataPagamento, bool recebido, long faturaId)
        {
            Numero = numero;
            Valor = valor;
            DataVencimento = dataVencimento;
            DataPagamento = dataPagamento;
            Recebido = recebido;
            FaturaId = faturaId;
            Validate(this, new ParcelaValidator());
        }
    }
}
