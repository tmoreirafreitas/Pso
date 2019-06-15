using PSO.BackEnd.Domain.Enum;
using PSO.BackEnd.Domain.Validators;

namespace PSO.BackEnd.Domain.Entities
{
    public class Telefone : Entity
    {
        public byte Ddd { get; set; }
        public string Numero { get; set; }
        public FoneType Tipo { get; set; }
        public Cliente Cliente { get; set; }

        public Telefone(byte ddd, string numero, FoneType tipo, Cliente cliente)
        {
            Ddd = ddd;
            Numero = numero;
            Tipo = tipo;
            Cliente = cliente;
            Validate(this, new TelefoneValidator());
        }
    }
}
