using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Options;
using NTTDATA.Application;
using NTTDATA.Application.Exceptions;
using NTTDATA.Application.Interfaces.Services;
using NTTDATA.Core.Entities;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class MovementController : ControllerBase
    {

        private readonly IMovementService _movimientoService;
        private readonly IOptions<AppSettings> _config;

        public MovementController(IMovementService movimientoService, IOptions<AppSettings> config)
        {
            _movimientoService = movimientoService;
            _config = config;
        }

        [HttpPost]
        [Route("process")]
        [ActionName("process")]
        [ProducesResponseType(200, Type = typeof(List<DetalleMovDTO>))]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [ProducesResponseType(StatusCodes.Status500InternalServerError)]
        public async Task<IActionResult> GenerateProcess(MovementDTO cliente)
        {
            var data = await _movimientoService.GenerateProcess(cliente);
            return Ok(new Response<List<DetalleMovDTO>>(data.detalleMov, data.codError, _config));
        }
    }
}
