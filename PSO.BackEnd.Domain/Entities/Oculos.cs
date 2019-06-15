using PSO.BackEnd.Domain.Validators;
using System;
using System.Collections.Generic;
using System.Linq;

namespace PSO.BackEnd.Domain.Entities
{
    public class Oculos : Entity
    {
        public IEnumerable<Lente> Lentes { get; private set; }
        public string Cor { get; private set; }
        public float DP { get; private set; }
        public float ALT { get; private set; }
        public Pedido Pedido { get; private set; }
        public float Adicao
        {
            get
            {
                float adicao = 0;

                if (Lentes != null && Lentes.Count() == 2)
                {
                    adicao = Lentes.ElementAt(0).Grau + Lentes.ElementAt(1).Grau;
                    return adicao;
                }
                else
                {
                    throw new ArgumentException("Erro no cálculo do grau do óculos, objeto OD ou OE são nulos!");
                }
            }
            private set { }
        }

        public Oculos(string cor, float dP, float aLT, Pedido pedido)
        {
            Cor = cor;
            DP = dP;
            ALT = aLT;
            Pedido = pedido;
            Lentes = new List<Lente>(2);
            Validate(this, new OculosValidator());
        }
    }
}
