using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Options;
using NTTDATA.Application;
using NTTDATA.Application.Exceptions;
using NTTDATA.Application.Interfaces.Services;
using NTTDATA.Core.Entities;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

//For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace API.Controllers
{
    [Route("Api/[controller]")]
    [ApiController]
    public class PersonController : ControllerBase
    {
        private readonly IPersonService _personaService;
        private readonly IOptions<AppSettings> _config;
        public PersonController(IPersonService personaService, IOptions<AppSettings> config)
        {
            _personaService = personaService;
            _config = config;
        }


        // GET: api/<PersonaController>
        [HttpGet]
        [Route("Get")]
        [ActionName("Get")]
        [ProducesResponseType(200, Type = typeof(List<ClienteRequestDTO>))]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [ProducesResponseType(StatusCodes.Status500InternalServerError)]
        public async Task<IActionResult> getPersonas(int? id)
        {
            var data = await _personaService.GetConsultaCasosCliente(id);
            return Ok(new Response<List<ClienteRequestDTO>>(data.clienteDTO, data.code, _config));

        }


        // POST api/<PersonaController>
        [HttpPost]
        [Route("Create")]
        [ActionName("Create")]
        [ProducesResponseType(200, Type = typeof(ClienteRequestDTO))]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [ProducesResponseType(StatusCodes.Status500InternalServerError)]
        public async Task<IActionResult> createPerson(ClienteDTO cliente)
        {
            var data = await _personaService.CreatePerson(cliente);
            return Ok(new Response<ClienteRequestDTO>(data.clienteDTO, data.code, _config));
        }


        [HttpPut]
        [Route("update")]
        [ActionName("update")]
        [ProducesResponseType(200, Type = typeof(ClienteRequestDTO))]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [ProducesResponseType(StatusCodes.Status500InternalServerError)]
        public async Task<IActionResult> updatePerson(ClienteDTO cliente)
        {
            var data = await _personaService.UpdatePerson(cliente);
            return Ok(new Response<ClienteRequestDTO>(data.clienteDTO, data.code, _config));
        }
        [HttpDelete]
        [Route("delete")]
        [ActionName("delete")]
        [ProducesResponseType(200, Type = typeof(bool))]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [ProducesResponseType(StatusCodes.Status500InternalServerError)]
        public async Task<IActionResult> deletePerson(long id)
        {
            var data = await _personaService.DeletePerson(id);
            return Ok(new Response<bool>(data, "000", _config));
        }
    }
}
