using AutoMapper;
using MediatR;
using Microsoft.AspNetCore.Mvc;
using Pso.BackEnd.Command.Request.RequestContato;
using Pso.BackEnd.WebApi.ViewModel;
using PSO.BackEnd.Domain.Entities;
using PSO.BackEnd.Domain.Interfaces.Repositories.NoSQLMdb.Read;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Pso.BackEnd.WebApi.Controllers
{
    [Produces("application/json")]
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


        // GET: api/Contato
        [HttpGet("cliente/{clienteId}")]
        [ProducesResponseType(200)]
        [ProducesResponseType(404)]
        [ProducesResponseType(500)]
        public async Task<IActionResult> GetByClienteId(long clienteId)
        {
            var cliente = await _clienteReadMongoRepository.SingleAsync(c => c.Id.Equals(clienteId));
            var contatos = cliente.Contatos;
            return Ok(_mapper.Map<IList<ContatoViewModel>>(contatos));
        }

        // GET: api/Contato/5
        [HttpGet("{id}/cliente/{clienteId}")]
        public async Task<IActionResult> GetById(long id, long clienteId)
        {

            var cliente = await _clienteReadMongoRepository.SingleAsync(c => c.Id.Equals(clienteId));
            var contato = cliente.Contatos.FirstOrDefault(c => c.Id.Equals(id));
            return Ok(_mapper.Map<ContatoViewModel>(contato));
        }

        // POST: api/Contato
        [HttpPost]
        [ProducesResponseType(201)]
        [ProducesResponseType(404)]
        [ProducesResponseType(500)]
        public async Task<IActionResult> Post([FromBody] ContatoViewModel contato)
        {
            var obj = _mapper.Map<Contato>(contato);
            var committed = await _mediator.Send(new CreateContatoCommand(obj));
            return Ok(committed);
        }

        // PUT: api/Contato/5
        [HttpPut]
        [ProducesResponseType(200)]
        [ProducesResponseType(400)]
        [ProducesResponseType(404)]
        [ProducesResponseType(500)]
        public async Task<IActionResult> Put([FromBody] ContatoViewModel contato)
        {
            var committed = await _mediator.Send(new UpdateContatoCommand(contato.Id, _mapper.Map<Contato>(contato))).ConfigureAwait(false);
            return Ok(committed);
        }

        // DELETE: api/ApiWithActions/5
        [HttpDelete("{id}")]
        [ProducesResponseType(200)]
        [ProducesResponseType(404)]
        [ProducesResponseType(500)]
        public async Task<IActionResult> Delete(int id)
        {
            var committed = await _mediator.Send(new DeleteContatoCommand(id)).ConfigureAwait(false);
            return Ok(committed);
        }
    }
}
