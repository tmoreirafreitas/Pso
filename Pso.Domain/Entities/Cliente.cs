using System;
using System.Collections.Generic;
using Pso.Domain.Enum;
using Pso.Domain.Validators;

namespace Pso.Domain.Entities
{
    public class Cliente : Entity
    {
        public string Nome { get; private set; }
        public string Rg { get; private set; }
        public string Cpf { get; private set; }
        public string Filiacao { get; private set; }
        public bool IsSPC { get; private set; }
        public DateTime Nascimento { get; private set; }
        public SexoType Sexo { get; private set; }
        public Endereco Endereco { get; set; }
        public IEnumerable<Contato> Contatos { get; private set; }
        public ICollection<Pedido> Pedidos { get; private set; }        

        public Cliente(string nome, string rg, string cpf, string filiacao, bool isSPC, DateTime nascimento, SexoType sexo)
        {
            Nome = nome;
            Rg = rg;
            Cpf = cpf;
            Filiacao = filiacao;
            IsSPC = isSPC ;
            Nascimento = nascimento;
            Sexo = sexo;
            Contatos = new List<Contato>();
            Pedidos = new List<Pedido>();
            Validate(this, new ClienteValidator());
        }
    }
}
