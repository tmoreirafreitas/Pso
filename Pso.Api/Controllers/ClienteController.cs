using AutoMapper;
using MediatR;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Pso.Api.InputModel;
using Pso.Api.ViewModel;
using Pso.Domain.Core.Cliente.Commands.Atualizar;
using Pso.Domain.Core.Cliente.Commands.Cadastrar;
using Pso.Domain.Core.Cliente.Commands.Deletar;
using Pso.Domain.Interfaces.Repositories.NoSqlMongoDb.Read;
using System.Collections.Generic;
using System.Threading;
using System.Threading.Tasks;

namespace Pso.Api.Controllers
{
    [Produces("application/json")]
    [Consumes("application/json")]
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

        [HttpGet]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status500InternalServerError)]
        public async Task<IActionResult> Get(CancellationToken cancellationToken)
        {
            var clientes = await _clienteReadMongoRepository.GetAllAsync(cancellationToken).ConfigureAwait(false);
            var clientesVieModel = _mapper.Map<ICollection<ClienteViewModel>>(clientes);
            return Ok(clientesVieModel);
        }

        [HttpGet("{id}")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        [ProducesResponseType(StatusCodes.Status500InternalServerError)]
        public async Task<IActionResult> GetById(long id, CancellationToken cancellationToken)
        {
            var cliente = await _clienteReadMongoRepository.GetByIdAsync(id, cancellationToken).ConfigureAwait(false);
            if (cliente == null)
                return NotFound("O cliente especificado não foi encontrado na base de dados.");
            return Ok(_mapper.Map<ClienteViewModel>(cliente));
        }

        [HttpGet("cpf/{cpf}")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        [ProducesResponseType(StatusCodes.Status500InternalServerError)]
        public async Task<IActionResult> GetByCpf(string cpf, CancellationToken cancellationToken)
        {
            var cliente = await _clienteReadMongoRepository.SingleAsync(c => c.Cpf.Equals(cpf), cancellationToken).ConfigureAwait(false);
            if (cliente == null)
                return NotFound("O CPF informado não existe na base de dados.");
            return Ok(_mapper.Map<ClienteViewModel>(cliente));
        }

        [HttpGet("fone/{phone}")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        [ProducesResponseType(StatusCodes.Status500InternalServerError)]
        public async Task<IActionResult> GetByPhone(string phone, CancellationToken cancellationToken)
        {
            var cliente = await _clienteReadMongoRepository.SingleAsync(c => c.Contatos, ct => ct.Telefone.Equals(phone), cancellationToken)
                .ConfigureAwait(false);
            if (cliente == null)
                return NotFound("O CPF informado não existe na base de dados.");
            return Ok(_mapper.Map<ClienteViewModel>(cliente));
        }

        [HttpGet("email/{email}")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        [ProducesResponseType(StatusCodes.Status500InternalServerError)]
        public async Task<IActionResult> GetByEmail(string email, CancellationToken cancellationToken)
        {
            var cliente = await _clienteReadMongoRepository.SingleAsync(c => c.Contatos, ct => ct.Email.Equals(email), cancellationToken)
                .ConfigureAwait(false);
            if (cliente == null)
                return NotFound("O CPF informado não existe na base de dados.");
            return Ok(_mapper.Map<ClienteViewModel>(cliente));
        }

        [HttpPost]
        [ProducesResponseType(StatusCodes.Status201Created)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [ProducesResponseType(StatusCodes.Status500InternalServerError)]
        public async Task<IActionResult> Post([FromBody] ClienteInputModel cliente, CancellationToken cancellationToken)
        {
            var command = _mapper.Map<CadastrarClienteCommand>(cliente);
            var response = await _mediator.Send(command, cancellationToken).ConfigureAwait(false);
            return CreatedAtAction(nameof(GetById), new { id = response.Data.Id }, _mapper.Map<ClienteViewModel>(response.Data));
        }

        [HttpPut("{id}")]
        [ProducesResponseType(StatusCodes.Status204NoContent)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [ProducesResponseType(StatusCodes.Status500InternalServerError)]
        public async Task<IActionResult> Put(long id, [FromBody] ClienteInputModel cliente, CancellationToken cancellationToken)
        {
            var command = _mapper.Map<AtualizarClienteCommand>(cliente);
            command.Id = id;
            await _mediator.Send(command, cancellationToken).ConfigureAwait(false);
            return NoContent();
        }

        [HttpDelete("{id}")]
        [ProducesResponseType(StatusCodes.Status204NoContent)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        [ProducesResponseType(StatusCodes.Status500InternalServerError)]
        public async Task<IActionResult> Delete(long id, CancellationToken cancellationToken)
        {
            var itemDeleted = await _mediator.Send(new DeletarClienteCommand(id), cancellationToken).ConfigureAwait(false);
            if (itemDeleted == null) return NotFound();
            return NotFound();
        }
    }
}