using Pso.Domain.Core.Notifications;

namespace Pso.Domain.Core.Contato.Commands.Cadastrar
{
    public class ContatoCadastrado : NotificationBase<CadastrarContatoCommand>
    {
        public override string ToString() => $"Novo contato do: \"{Command.Nome}\" foi cadastrado no dia {DataHora:dd/MM/yyyy HH:mm:ss}";
        public ContatoCadastrado(CadastrarContatoCommand command) : base(command)
        {
        }
    }
}