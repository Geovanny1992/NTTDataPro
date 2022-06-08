using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Options;
using NTTDATA.Application;
using NTTDATA.Application.Dtos;
using NTTDATA.Application.Exceptions;
using NTTDATA.Application.Interfaces.Services;
using NTTDATA.Core.Entities;
using System;
using System.Collections.Generic;
using System.Globalization;
using System.Threading.Tasks;

namespace API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ReportsController : ControllerBase
    {
        private readonly IReporteService _reporteService;
        private readonly IOptions<AppSettings> _config;
        public ReportsController(IReporteService reporteService, IOptions<AppSettings> config)
        {
            _reporteService = reporteService;
            _config = config;
        }
        [HttpGet]
        [Route("Get")]
        [ActionName("Get")]
        [ProducesResponseType(200, Type = typeof(ResponseBaseListAccountDTO))]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [ProducesResponseType(StatusCodes.Status500InternalServerError)]
        public async Task<IActionResult> getMovement(string numCuenta, string fecha)
        {
            var _fecha = DateTime.Parse(fecha, CultureInfo.InvariantCulture);
            var data = await _reporteService.GetReports(_fecha, numCuenta);
            return Ok(new Response<ResponseBaseListRepoDTO>(data, data.code, _config));

        }
    }
}
