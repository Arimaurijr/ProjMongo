using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using ProjMongo.Models;
using ProjMongo.Services;

namespace ProjMongo.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ClienteController : ControllerBase
    {
        private readonly ClientService _clientService;

        public ClienteController(ClientService clientService)
        {
            _clientService = clientService;
        }
        [HttpGet]
        public ActionResult<List<Cliente>> Get() => _clientService.Get();

        [HttpGet("{id:length(24)}", Name = "GetClient")]
        public ActionResult<Cliente> Get(string id)
        {
            var client = _clientService.Get(id);
            if (client == null) return NotFound();

            return _clientService.Get(id);
        }

        [HttpPost]
        public ActionResult<Cliente> Create(Cliente cliente)
        {
            return _clientService.Create(cliente);
            /*
            _clientService.Create(cliente);
            return CreatedAtRoute("GetClient", new { id = cliente.Id }, cliente);
            */
        }
        [HttpPut("{id:length(24)}")]
        public ActionResult Update(string id, Cliente cliente)
        {
            var c = _clientService.Get(id);
            if (c == null) return NotFound();

            _clientService.Update(id, cliente);
            return Ok();
        }
        [HttpDelete("{id:length(24)}")]
        public ActionResult Delete(string id)
        {
            if (id == null) return NotFound();
            var cliente = _clientService.Get(id);
            if(cliente == null) return NotFound();

            _clientService.Delete(id);
            return Ok();
        }
    }
}
