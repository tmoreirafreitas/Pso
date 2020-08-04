namespace Pso.Domain.Core.Contato.Commands.Deletar
{
    public class DeletarContatoCommand : DeleteCommand
    {
        public long ClientId { get; }
        //public DeletarContatoCommand(long contatoId, long clientId)
        //{
        //    ClientId = clientId;
        //    ContatoId = contatoId;
        //}
        public DeletarContatoCommand(long contatoId, long clientId) : base(contatoId)
        {
            ClientId = clientId;
        }
    }
}