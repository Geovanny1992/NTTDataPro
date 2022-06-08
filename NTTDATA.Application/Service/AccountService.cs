using AutoMapper;
using Microsoft.Extensions.Options;
using NTTDATA.Application.Interfaces.Repositories;
using NTTDATA.Application.Interfaces.Services;
using NTTDATA.Core.Entities;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace NTTDATA.Application.Service
{
    public class AccountService : IAccountService
    {
        private readonly IAccountRepository _accountRepository;
        public readonly IMapper _mapper;
        private readonly IOptions<AppSettings> _config;

        public AccountService(IAccountRepository accountRepository, IMapper mapper, IOptions<AppSettings> config)
        {
            _accountRepository = accountRepository;
            _mapper = mapper;
            _config = config;
        }
        public async Task<ResponseBaseAccountDTO> CreateUpdateAccount(AccountDTO account)
        {
            try
            {
                if (account.NumeroCuenta.Length < 0)
                {
                    return new ResponseBaseAccountDTO()
                    {
                        Cuenta = null,
                        code = "0022"
                    };
                }
             
                var resul = _mapper.Map<Cuenta>(account);
                var request = await _accountRepository.CreateUpdateAccount(resul);
                return new ResponseBaseAccountDTO()
                {
                    Cuenta = _mapper.Map<AccountDTO>(request.Account),
                    code = request.code
                };

            }
            catch (Exception e)
            {
                throw e;
            }
        }

        public async Task<bool> DeleteAccount(long id)
        {
            try
            {
                if (id > 0)
                {
                    var request = await _accountRepository.DeleteAccount(id);
                    return request ? true : false;
                }
                return true;
            }
            catch (Exception e)
            {
                throw e;
            }
        }

        public async Task<ResponseBaseListAccountDTO> GetAccount(int? id)
        {           
            var request = await _accountRepository.GetAccount(id);
            return new ResponseBaseListAccountDTO()
            {
                Accountdto = _mapper.Map<List<AccountDTO>>(request.Account),
                code = request.code
            };
        }


    }
}
