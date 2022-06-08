using NTTDATA.Core.Entities;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace NTTDATA.Application.Interfaces.Services
{
    public interface IAccountService
    {
        Task<ResponseBaseListAccountDTO> GetAccount(int? id);
        Task<ResponseBaseAccountDTO> CreateUpdateAccount(AccountDTO cliente);
        Task<bool> DeleteAccount(long id);
    }
}
