using System;

namespace Pso.BackEnd.WebApi.ViewModel
{
    public class EnderecoViewModel : EntityBaseViewModel
    {
        public string Cep { get; set; }
        public string Logradouro { get; set; }
        public string Bairro { get; set; }
        public string Cidade { get; set; }
        public string Estado { get; set; }
        public int? Numero { get; set; }
        public string Complemento { get; set; }
        public long ClienteId { get; set; }
    }
}
