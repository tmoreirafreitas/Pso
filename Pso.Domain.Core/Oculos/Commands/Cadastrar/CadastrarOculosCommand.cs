using System;
using System.Collections.Generic;
using System.Linq;
using Pso.Domain.Core.Lente.Commands.Cadastrar;
using Pso.Domain.Core.Pedido.Commands.Cadastrar;
using Pso.Domain.Core.Validators;

namespace Pso.Domain.Core.Oculos.Commands.Cadastrar
{
    public class CadastrarOculosCommand : Command<Entities.Oculos>
    {
        public ICollection<CadastrarLenteCommand> Lentes { get; private set; }
        public string Cor { get; private set; }
        public float DP { get; private set; }
        public float ALT { get; private set; }
        public long PedidoOculosId { get; private set; }
        public ICollection<CadastrarPedidoOculosCommand> PedidosOculos { get; private set; }
        public float Adicao
        {
            get
            {
                if (Lentes != null && Lentes.Count() == 2)
                {
                    float adicao = Lentes.ElementAt(0).Grau + Lentes.ElementAt(1).Grau;
                    return adicao;
                }
                else
                {
                    throw new ArgumentException("Erro no cálculo do grau do óculos, objeto OD ou OE são nulos!");
                }
            }
            private set { }
        }

        public CadastrarOculosCommand(long pedidoOculosId, string cor, float dP, float aLT)
        {
            PedidoOculosId = pedidoOculosId;
            Cor = cor;
            DP = dP;
            ALT = aLT;
            PedidosOculos = new List<CadastrarPedidoOculosCommand>();
            Lentes = new List<CadastrarLenteCommand>(2);
        }
    }
}