﻿using System;
using System.Collections.Generic;
using Pso.Domain.Enum;
using Pso.Domain.Validators;

namespace Pso.Domain.Entities
{
    public class Fatura : Entity
    {
        public decimal Valor { get; private set; }
        public decimal Total { get; private set; }
        public decimal Sinal { get; private set; }
        public bool IsPaga { get; private set; }
        public DateTime DataPagamento { get; private set; }
        public int NumeroParcelas { get; private set; }
        public FormaPagamento FormaPagamento { get; private set; }
        public long PedidoId { get; private set; }
        public Pedido Pedido { get; set; }
        public ICollection<Parcela> Parcelas { get; private set; }

        public Fatura(decimal valor, decimal total, decimal sinal, bool isPaga, 
            DateTime dataPagamento, int numeroParcelas, FormaPagamento formaPagamento, long pedidoId)
        {
            Valor = valor;
            Total = total;
            Sinal = sinal;
            IsPaga = isPaga;
            DataPagamento = dataPagamento;
            NumeroParcelas = numeroParcelas;
            FormaPagamento = formaPagamento;
            Parcelas = new List<Parcela>();
            PedidoId = pedidoId;
            Validate(this, new FaturaValidator());
        }
    }
}
