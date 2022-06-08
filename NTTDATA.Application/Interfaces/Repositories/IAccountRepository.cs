using NTTDATA.Core.Entities;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace NTTDATA.Application.Interfaces.Repositories
{
    public interface IAccountRepository
    {
        Task<ResponseBaseAccountList> GetAccount(int? id);
        Task<ResponseBaseAccount> CreateUpdateAccount(Cuenta cliente);   
        Task<bool> DeleteAccount(long id);
    }
}
