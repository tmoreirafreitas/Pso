using Pso.Domain.Core.Notifications;
using System;

namespace Pso.Domain.Core.Cliente.Commands.Cadastrar
{
    public class ClienteCadastrado : NotificationBase<CadastrarClienteCommand>
    {
        public override string ToString() => $"Novo Cliente com o CPF: \"{Command.Cpf}\" foi cadastrado no dia {DataHora:dd/MM/yyyy HH:mm:ss}";

        public ClienteCadastrado(CadastrarClienteCommand command) : base(command)
        {
            
        }
    }
}