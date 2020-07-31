using Pso.Domain.Core.Notifications;

namespace Pso.Domain.Core.Cliente.Commands.Atualizar
{
    public class ClienteAtualizado : NotificationBase<AtualizarClienteCommand>
    {
        public override string ToString() => $"Os dados do cliente com o CPF: \"{Command.Cpf}\" foi atualizado no dia {DataHora:dd/MM/yyyy HH:mm:ss}";
        public ClienteAtualizado(AtualizarClienteCommand command) : base(command)
        {
        }
    }
}