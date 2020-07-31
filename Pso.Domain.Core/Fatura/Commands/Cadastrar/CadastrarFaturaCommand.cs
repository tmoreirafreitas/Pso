using System;
using System.Collections.Generic;
using Pso.Domain.Core.Parcela.Commands.Cadastrar;
using Pso.Domain.Core.Pedido.Commands.Cadastrar;
using Pso.Domain.Core.Validators;
using Pso.Domain.Enum;

namespace Pso.Domain.Core.Fatura.Commands.Cadastrar
{
    public class CadastrarFaturaCommand : Command<Entities.Fatura>
    {
        public decimal Valor { get; private set; }
        public decimal Total { get; private set; }
        public decimal Sinal { get; private set; }
        public bool IsPaga { get; private set; }
        public DateTime DataPagamento { get; private set; }
        public int NumeroParcelas { get; private set; }
        public FormaPagamento FormaPagamento { get; private set; }
        public long PedidoId { get; private set; }
        public CadastrarPedidoCommand Pedido { get; set; }
        public ICollection<CadastrarParcelaCommand> Parcelas { get; private set; }

        public CadastrarFaturaCommand(decimal valor, decimal total, decimal sinal, bool isPaga,
            DateTime dataPagamento, int numeroParcelas, FormaPagamento formaPagamento, long pedidoId)
        {
            Valor = valor;
            Total = total;
            Sinal = sinal;
            IsPaga = isPaga;
            DataPagamento = dataPagamento;
            NumeroParcelas = numeroParcelas;
            FormaPagamento = formaPagamento;
            Parcelas = new List<CadastrarParcelaCommand>();
            PedidoId = pedidoId;
            Validate(this, new CadastrarFaturaCommandValidator());
        }
    }
}