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
    public class AccountController : ControllerBase
    {
        private readonly IAccountService _accountService;
        private readonly IOptions<AppSettings> _config;
        public AccountController(IAccountService ccountService, IOptions<AppSettings> config)
        {
            _accountService = ccountService;
            _config = config;
        }

        [HttpGet]
        [Route("Get")]
        [ActionName("Get")]
        [ProducesResponseType(200, Type = typeof(ResponseBaseListAccountDTO))]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [ProducesResponseType(StatusCodes.Status500InternalServerError)]
        public async Task<IActionResult> getAccount(int? id)
        {
            var data = await _accountService.GetAccount(id);
            return Ok(new Response<ResponseBaseListAccountDTO>(data, data.code, _config));

        }

        [HttpPost]
        [Route("CreateUpdate")]
        [ActionName("CreateUpdate")]
        [ProducesResponseType(200, Type = typeof(ResponseBaseAccountDTO))]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [ProducesResponseType(StatusCodes.Status500InternalServerError)]
        public async Task<IActionResult> CreateUpdateAccount(AccountDTO cliente)
        {
            var data = await _accountService.CreateUpdateAccount(cliente);
            return Ok(new Response<AccountDTO>(data.Cuenta, data.code, _config));
        }

        [HttpDelete]
        [Route("delete")]
        [ActionName("delete")]
        [ProducesResponseType(200, Type = typeof(bool))]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [ProducesResponseType(StatusCodes.Status500InternalServerError)]
        public async Task<IActionResult> deleteAccount(long id)
        {
            var data = await _accountService.DeleteAccount(id);
            return Ok(new Response<bool>(data, "000", _config));
        }
    }
}
