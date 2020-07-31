namespace Pso.Domain.Core.Endereco.Commands.Deletar
{
    public class DeletarEnderecoCommand : DeleteCommand<Entities.Endereco>
    {
        public DeletarEnderecoCommand(long id) : base(id)
        {
        }
    }
}