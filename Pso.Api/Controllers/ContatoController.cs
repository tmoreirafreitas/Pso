using AutoMapper;
using MediatR;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Pso.Api.InputModel;
using Pso.Domain.Core.Contato.Commands.Cadastrar;
using Pso.Domain.Core.Contato.Commands.Deletar;
using Pso.Domain.Interfaces.Repositories.NoSqlMongoDb.Read;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Pso.Api.Controllers
{
    [Produces("application/json")]
    [Consumes("application/json")]
    [Route("api/contato")]
    [ApiController]
    public class ContatoController : ControllerBase
    {
        private readonly IMediator _mediator;
        private readonly IMapper _mapper;
        private readonly IClienteReadMongoRepository _clienteReadMongoRepository;

        public ContatoController(IMediator mediator, IMapper mapper, IClienteReadMongoRepository clienteReadMongoRepository)
        {
            _mediator = mediator;
            _mapper = mapper;
            _clienteReadMongoRepository = clienteReadMongoRepository;
        }

        [HttpGet("cliente/{clienteId}")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        [ProducesResponseType(StatusCodes.Status500InternalServerError)]
        public async Task<IActionResult> GetByClienteId(long clienteId)
        {
            var cliente = await _clienteReadMongoRepository.SingleAsync(c => c.Id.Equals(clienteId));
            var contatos = cliente.Contatos;
            return Ok(_mapper.Map<IList<ContatoInputModel>>(contatos));
        }

        [HttpGet("{id}/cliente/{clienteId}")]
        public async Task<IActionResult> GetById(long id, long clienteId)
        {

            var cliente = await _clienteReadMongoRepository.SingleAsync(c => c.Id.Equals(clienteId));
            var contato = cliente.Contatos.FirstOrDefault(c => c.Id.Equals(id));
            return Ok(_mapper.Map<ContatoInputModel>(contato));
        }

        [HttpPost]
        [ProducesResponseType(StatusCodes.Status201Created)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [ProducesResponseType(StatusCodes.Status500InternalServerError)]
        public async Task<IActionResult> Post([FromBody] ContatoInputModel contato)
        {
            var command = _mapper.Map<CadastrarContatoCommand>(contato);
            var committed = await _mediator.Send(command);
            return CreatedAtAction(nameof(GetById), new { id = committed.Data.Id }, committed.Data);
        }

        [HttpPut]
        [ProducesResponseType(StatusCodes.Status204NoContent)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [ProducesResponseType(StatusCodes.Status500InternalServerError)]
        public async Task<IActionResult> Put([FromBody] ContatoInputModel contato)
        {
            var command = _mapper.Map<CadastrarContatoCommand>(contato);
            await _mediator.Send(command).ConfigureAwait(false);
            return NoContent();
        }

        [HttpDelete("{contatoId}/cliente/{clienteId}")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [ProducesResponseType(StatusCodes.Status500InternalServerError)]
        public async Task<IActionResult> Delete(long contatoId, long clienteId)
        {
            await _mediator.Send(new DeletarContatoCommand(contatoId, clienteId)).ConfigureAwait(false);
            return Ok();
        }
    }
}