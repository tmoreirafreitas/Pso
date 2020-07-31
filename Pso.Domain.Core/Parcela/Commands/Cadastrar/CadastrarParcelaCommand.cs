using System;
using Pso.Domain.Core.Fatura.Commands.Cadastrar;
using Pso.Domain.Core.Validators;

namespace Pso.Domain.Core.Parcela.Commands.Cadastrar
{
    public class CadastrarParcelaCommand : Command<Entities.Parcela>
    {
        public int Numero { get; private set; }
        public decimal Valor { get; private set; }
        public DateTime DataVencimento { get; private set; }
        public DateTime DataPagamento { get; private set; }
        public bool Recebido { get; private set; }
        public long FaturaId { get; private set; }
        public CadastrarFaturaCommand Fatura { get; private set; }
        public CadastrarParcelaCommand(int numero, decimal valor, DateTime dataVencimento, DateTime dataPagamento, bool recebido, long faturaId)
        {
            Numero = numero;
            Valor = valor;
            DataVencimento = dataVencimento;
            DataPagamento = dataPagamento;
            Recebido = recebido;
            FaturaId = faturaId;
            Validate(this, new CadastrarParcelaCommandValidator());
        }
    }
}