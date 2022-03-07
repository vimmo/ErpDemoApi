using ErpDemoEF.Models;
using ErpDemoEF.Services;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ErpDemoApi.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class ClientiController : ControllerBase
    {
        private readonly ILogger<ClientiController> _logger;
        private readonly IDBClientiService _dBClientiService;

        public ClientiController(ILogger<ClientiController> logger, IDBClientiService dBClientiService)
        {
            _logger = logger;
            _dBClientiService = dBClientiService;
        }

        [HttpGet]
        public IEnumerable<Clienti> Get()
        {
            return _dBClientiService.GetClienti();
        }
        [HttpGet("{id}")]
        public Clienti Get(int id)
        {
            return _dBClientiService.GetClienti(id);
        }
        [HttpPost]
        public async Task<ActionResult<Clienti>> PostCliente(Clienti cliente)
        {
            return await _dBClientiService.PostCliente(cliente);
        }
        [HttpPut("{id}")]
        public async Task<ActionResult<Clienti>> PutCliente(int id, Clienti cliente)
        {
            if (id != cliente.Id)
            {
                return BadRequest();
            }
            return await _dBClientiService.PutCliente(cliente);
        }
        [HttpDelete("{id}")]
        public ActionResult<Clienti> DeleteCliente(int id)
        {
            var cliente =  _dBClientiService.FindCliente(id);
            if (cliente == null)
            {
                return NotFound();
            }

             _dBClientiService.DeleteCliente(cliente);
            return NoContent();
        }

    }
}
