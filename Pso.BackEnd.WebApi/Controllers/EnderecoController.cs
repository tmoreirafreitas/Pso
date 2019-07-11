using AutoMapper;
using MediatR;
using Microsoft.AspNetCore.Mvc;
using Pso.BackEnd.Command.Request.RequestEndereco;
using Pso.BackEnd.WebApi.ViewModel;
using PSO.BackEnd.Domain.Entities;
using PSO.BackEnd.Domain.Interfaces.Repositories.NoSQLMdb.Read;
using System.Threading.Tasks;

namespace Pso.BackEnd.WebApi.Controllers
{
    [Produces("application/json")]
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

        // GET: api/Endereco
        [HttpGet("cliente/{clienteId}")]
        [ProducesResponseType(200)]
        [ProducesResponseType(404)]
        [ProducesResponseType(500)]
        public async Task<IActionResult> Get(long clienteId)
        {
            var cliente = await _clienteReadMongoRepository.SingleAsync(c => c.Endereco.ClienteId.Equals(clienteId));
            var endereco = cliente.Endereco;
            return Ok(_mapper.Map<EnderecoViewModel>(endereco));
        }

        // POST: api/Endereco
        [HttpPost]
        [ProducesResponseType(201)]
        [ProducesResponseType(404)]
        [ProducesResponseType(500)]
        public async Task<IActionResult> Post([FromBody] EnderecoViewModel endereco)
        {
            var committed = await _mediator.Send(new CreateEnderecoCommand(_mapper.Map<Endereco>(endereco)));
            return Ok(committed);
        }

        // PUT: api/Endereco/5
        [HttpPut("{id}")]
        [ProducesResponseType(200)]
        [ProducesResponseType(400)]
        [ProducesResponseType(404)]
        [ProducesResponseType(500)]
        public async Task<IActionResult> Put(long id, [FromBody] EnderecoViewModel endereco)
        {
            var committed = await _mediator.Send(new UpdateEnderecoCommand(id, _mapper.Map<Endereco>(endereco)));
            return Ok(committed);
        }

        // DELETE: api/ApiWithActions/5
        [HttpDelete("{id}")]
        [ProducesResponseType(200)]
        [ProducesResponseType(404)]
        [ProducesResponseType(500)]
        public async Task<IActionResult> Delete(int id)
        {
            var committed = await _mediator.Send(new DeleteEnderecoCommand(id)).ConfigureAwait(false);
            return Ok(committed);
        }
    }
}
