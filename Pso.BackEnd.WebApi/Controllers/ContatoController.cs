using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using AutoMapper;
using MediatR;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Pso.BackEnd.WebApi.ViewModel;
using PSO.BackEnd.Domain.Interfaces.Repositories.NoSQLMdb.Read;

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
        public void Post([FromBody] string value)
        {
        }

        // PUT: api/Contato/5
        [HttpPut("{id}")]
        public void Put(int id, [FromBody] string value)
        {
        }

        // DELETE: api/ApiWithActions/5
        [HttpDelete("{id}")]
        public void Delete(int id)
        {
        }
    }
}
