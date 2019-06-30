using PSO.BackEnd.Domain.Validators;
using System;
using System.Collections.Generic;
using System.Linq;

namespace PSO.BackEnd.Domain.Entities
{
    public class Oculos : Entity
    {
        public ICollection<Lente> Lentes { get; private set; }
        public string Cor { get; private set; }
        public float DP { get; private set; }
        public float ALT { get; private set; }
        public long PedidoOculosId { get; private set; }
        //public ICollection<Pedido> Pedidos { get; private set; }
        public ICollection<PedidoOculos> PedidosOculos { get; private set; }
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

        public Oculos(long pedidoOculosId, string cor, float dP, float aLT)
        {
            PedidoOculosId = pedidoOculosId;
            Cor = cor;
            DP = dP;
            ALT = aLT;
            PedidosOculos = new List<PedidoOculos>();
            Lentes = new List<Lente>(2);
            Validate(this, new OculosValidator());
        }
    }
}
