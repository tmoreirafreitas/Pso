namespace Pso.Domain.Core.Contato.Commands.Deletar
{
    public class DeletarContatoCommand : DeleteCommand<Entities.Contato>
    {
        public long ClientId { get; }
        public DeletarContatoCommand(long contatoId, long clientId) : base(contatoId)
        {
            ClientId = clientId;
        }
    }
}