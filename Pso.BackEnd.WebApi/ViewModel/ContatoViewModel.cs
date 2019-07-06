using System;

namespace Pso.BackEnd.WebApi.ViewModel
{
    public class ContatoViewModel: EntityBaseViewModel
    {
        public string Nome { get; set; }
        public string Telefone { get; set; }
        public string Email { get; set; }
        public long ClienteId { get; set; }
    }
}
