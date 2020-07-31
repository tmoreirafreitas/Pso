namespace Pso.Domain.Core.Cliente.Commands.Deletar
{
    public class DeletarClienteCommand : DeleteCommand<Entities.Cliente>
    {
        public DeletarClienteCommand(long id) : base(id)
        {
        }
    }
}