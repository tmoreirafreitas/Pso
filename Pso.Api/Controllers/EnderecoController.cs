using AutoMapper;
using MediatR;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Pso.Domain.Interfaces.Repositories.NoSqlMongoDb.Read;
using System.Threading.Tasks;
using Pso.Api.InputModel;
using Pso.Domain.Core.Endereco.Commands.Cadastrar;
using Pso.Domain.Core.Endereco.Commands.Deletar;

namespace Pso.Api.Controllers
{
    [Produces("application/json")]
    [Consumes("application/json")]
    [Route("api/endereco")]
    [ApiController]
    public class EnderecoController : ControllerBase
    {
        private readonly IMediator _mediator;
        private readonly IMapper _mapper;
        private readonly IClienteReadMongoRepository _clienteReadMongoRepository;

        public EnderecoController(IMediator mediator, IMapper mapper, IClienteReadMongoRepository clienteReadMongoRepository)
        {
            _mediator = mediator;
            _mapper = mapper;
            _clienteReadMongoRepository = clienteReadMongoRepository;
        }

        [HttpGet("cliente/{clienteId}")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        [ProducesResponseType(StatusCodes.Status500InternalServerError)]
        public async Task<IActionResult> Get(long clienteId)
        {
            var cliente = await _clienteReadMongoRepository.SingleAsync(c => c.Endereco.ClienteId.Equals(clienteId));
            var endereco = cliente.Endereco;
            return Ok(_mapper.Map<EnderecoInputModel>(endereco));
        }

        [HttpPost]
        [ProducesResponseType(StatusCodes.Status201Created)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [ProducesResponseType(StatusCodes.Status500InternalServerError)]
        public async Task<IActionResult> Post([FromBody] EnderecoInputModel endereco)
        {
            var command = _mapper.Map<CadastrarEnderecoCommand>(endereco);
            var committed = await _mediator.Send(command).ConfigureAwait(false);
            return CreatedAtAction(nameof(Get), new { id = committed.Data.Id }, committed.Data);
        }

        [HttpPut]
        [ProducesResponseType(StatusCodes.Status204NoContent)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [ProducesResponseType(StatusCodes.Status500InternalServerError)]
        public async Task<IActionResult> Put([FromBody] EnderecoInputModel endereco)
        {
            var command = _mapper.Map<CadastrarEnderecoCommand>(endereco);
            await _mediator.Send(command).ConfigureAwait(false);
            return NoContent();
        }

        [HttpDelete("{id}")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status500InternalServerError)]
        public async Task<IActionResult> Delete(int id)
        {
            await _mediator.Send(new DeletarEnderecoCommand(id)).ConfigureAwait(false);
            return Ok();
        }
    }
}