using System.Threading;
using System.Threading.Tasks;
using AutoMapper;
using MediatR;
using Pso.Domain.Interfaces.Repositories.NoSqlMongoDb.Write;

namespace Pso.Domain.Core.Cliente.Commands.Atualizar
{
    public class ClienteAtualizadoNotificationHandler: INotificationHandler<ClienteAtualizado>
    {
        private readonly IClienteWriteMongoRepository _clienteWriteMongoRepository;
        private readonly IMapper _mapper;

        public ClienteAtualizadoNotificationHandler(IClienteWriteMongoRepository clienteWriteMongoRepository, IMapper mapper)
        {
            _clienteWriteMongoRepository = clienteWriteMongoRepository;
            _mapper = mapper;
        }

        public Task Handle(ClienteAtualizado notification, CancellationToken cancellationToken)
        {
            var cliente = _mapper.Map<Entities.Cliente>(notification.Command);
            _clienteWriteMongoRepository.UpdateAsync(cliente);
            return Task.CompletedTask;
        }
    }
}