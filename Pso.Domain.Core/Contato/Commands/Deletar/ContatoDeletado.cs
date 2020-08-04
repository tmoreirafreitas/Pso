using Pso.Domain.Core.Notifications;

namespace Pso.Domain.Core.Contato.Commands.Deletar
{
    public class ContatoDeletado : NotificationBase<DeletarContatoCommand>
    {
        public override string ToString() => $"Contato deletado no dia {DataHora:dd/MM/yyyy HH:mm:ss}";
        public ContatoDeletado(DeletarContatoCommand command) : base(command)
        {
        }
    }
}