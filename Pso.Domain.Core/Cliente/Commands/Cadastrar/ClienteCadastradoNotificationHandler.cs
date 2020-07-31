using AutoMapper;
using MediatR;
using Pso.Domain.Interfaces.Repositories.NoSqlMongoDb.Write;
using System.Threading;
using System.Threading.Tasks;

namespace Pso.Domain.Core.Cliente.Commands.Cadastrar
{
    public class ClienteCadastradoNotificationHandler : INotificationHandler<ClienteCadastrado>
    {
        private readonly IClienteWriteMongoRepository _clienteWriteMongoRepository;
        private readonly IMapper _mapper;

        public ClienteCadastradoNotificationHandler(IClienteWriteMongoRepository clienteWriteMongoRepository, IMapper mapper)
        {
            _clienteWriteMongoRepository = clienteWriteMongoRepository;
            _mapper = mapper;
        }

        public Task Handle(ClienteCadastrado notification, CancellationToken cancellationToken)
        {
            var cliente = _mapper.Map<Entities.Cliente>(notification.Command);
            _clienteWriteMongoRepository.AddAsync(cliente);
            return Task.CompletedTask;
        }
    }
}