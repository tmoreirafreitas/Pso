using PSO.BackEnd.Domain.Validators;
using System;
using System.Collections.Generic;
using System.Text;

namespace PSO.BackEnd.Domain.Entities
{
    public class Parcela : Entity
    {
        public int Numero { get; private set; }
        public decimal Valor { get; private set; }
        public DateTime DataVencimento { get; private set; }
        public DateTime DataPagamento { get; private set; }
        public bool Recebido { get; private set; }
        public Fatura Fatura { get; set; }
        public Parcela(int numero, decimal valor, DateTime dataVencimento, DateTime dataPagamento, bool recebido, Fatura fatura)
        {
            Numero = numero;
            Valor = valor;
            DataVencimento = dataVencimento;
            DataPagamento = dataPagamento;
            Recebido = recebido;
            Fatura = fatura;
            Validate(this, new ParcelaValidator());
        }
    }
}
