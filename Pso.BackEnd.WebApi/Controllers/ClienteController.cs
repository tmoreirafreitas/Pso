using AutoMapper;
using MediatR;
using Microsoft.AspNetCore.Mvc;
using Pso.BackEnd.Command.Request.RequestCliente;
using Pso.BackEnd.Infra.CrossCutting.NotificationsAndFilters;
using Pso.BackEnd.WebApi.ViewModel;
using PSO.BackEnd.Domain.Entities;
using PSO.BackEnd.Domain.Interfaces.Repositories.NoSQLMdb.Read;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Pso.BackEnd.WebApi.Controllers
{
    [Route("api/cliente")]
    [ApiController]
    public class ClienteController : ControllerBase
    {
        private readonly IMediator _mediator;
        private readonly IMapper _mapper;
        private readonly IClienteReadMongoRepository _clienteReadMongoRepository;

        public ClienteController(IMediator mediator, IMapper mapper, IClienteReadMongoRepository clienteReadMongoRepository)
        {
            _mediator = mediator;
            _mapper = mapper;
            _clienteReadMongoRepository = clienteReadMongoRepository;
        }

        // GET: api/Cliente
        [HttpGet]
        [ProducesResponseType(200)]
        [ProducesResponseType(500)]
        [ProducesResponseType(404)]
        public async Task<IActionResult> Get()
        {
            var clientes = await _clienteReadMongoRepository.GetAllAsync();
            if (clientes == null)
                throw new NotFoundException("Não há clientes registrados");
            var clientesVieModel = _mapper.Map<IEnumerable<ClienteViewModel>>(clientes);
            return Ok(clientesVieModel);
        }

        //// GET: api/Cliente/5
        [ProducesResponseType(200)]
        [ProducesResponseType(500)]
        [ProducesResponseType(404)]
        [HttpGet("{id}", Name = "Get")]
        public async Task<IActionResult> Get(long id)
        {
            var cliente = await _clienteReadMongoRepository.GetByIdAsync(id);
            if (cliente == null)
                throw new NotFoundException("O cliente especificado não foi encontrado na base de dados.");
            return Ok(_mapper.Map<ClienteViewModel>(cliente));
        }

        [ProducesResponseType(200)]
        [ProducesResponseType(500)]
        [ProducesResponseType(404)]
        [HttpGet("{cpf}", Name = "GetByCpf")]
        public async Task<IActionResult> GetByCpf(string cpf)
        {
            var cliente = await _clienteReadMongoRepository.SingleAsync(c => c.Cpf.Equals(cpf));
            if (cliente == null)
                throw new NotFoundException("O CPF informado não existe na base de dados.");
            return Ok(_mapper.Map<ClienteViewModel>(cliente));
        }

        [ProducesResponseType(200)]
        [ProducesResponseType(500)]
        [ProducesResponseType(404)]
        [HttpGet("{phone}", Name = "GetByPhone")]
        public async Task<IActionResult> GetByPhone(string phone)
        {
            var cliente = await _clienteReadMongoRepository.SingleAsync(c => c.Contatos.FirstOrDefault(t => t.Telefone.Equals(phone)) != null);
            if (cliente == null)
                throw new NotFoundException("O CPF informado não existe na base de dados.");
            return Ok(_mapper.Map<ClienteViewModel>(cliente));
        }

        [ProducesResponseType(200)]
        [ProducesResponseType(500)]
        [ProducesResponseType(404)]
        [HttpGet("{email}", Name = "GetByEmail")]
        public async Task<IActionResult> GetByEmail(string email)
        {
            var cliente = await _clienteReadMongoRepository.SingleAsync(c => 
            c.Contatos.FirstOrDefault(t => t.Email.ToLower().Equals(email.ToLower())) != null);
            if (cliente == null)
                throw new NotFoundException("O CPF informado não existe na base de dados.");
            return Ok(_mapper.Map<ClienteViewModel>(cliente));
        }

        // POST: api/Cliente
        [HttpPost]
        [ProducesResponseType(201)]
        [ProducesResponseType(500)]
        [ProducesResponseType(404)]
        public async Task<IActionResult> Post([FromBody] ClienteViewModel cliente)
        {
            var obj = _mapper.Map<Cliente>(cliente);
            await _mediator.Send(new CreateClienteCommand(obj)).ConfigureAwait(false);
            return Ok();
        }

        // PUT: api/Cliente/5
        [HttpPut("{id}")]
        public async Task<IActionResult> Put(int id, [FromBody] ClienteViewModel cliente)
        {
            await _mediator.Send(new UpdateClienteCommand(id, _mapper.Map<Cliente>(cliente))).ConfigureAwait(false);
            return Ok();
        }

        // DELETE: api/ApiWithActions/5
        [ProducesResponseType(200)]
        [ProducesResponseType(500)]
        [ProducesResponseType(404)]
        [HttpDelete("{id}")]
        public async Task<IActionResult> Delete(long id)
        {
            await _mediator.Send(new DeleteClienteCommand(id)).ConfigureAwait(false);
            return Ok();
        }
    }
}
