using MediatR;
using Pso.Domain.Core.Notifications;

namespace Pso.Domain.Core.Cliente.Commands.Deletar
{
    public class ClienteDeletado: NotificationBase<DeletarClienteCommand>
    {
        public override string ToString() => $"O Cliente com o ID: \"{Command.Id}\" foi apagado no dia {DataHora:dd/MM/yyyy HH:mm:ss}";

        public ClienteDeletado(DeletarClienteCommand command) : base(command)
        {
        }
    }
}