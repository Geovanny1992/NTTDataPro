using NTTDATA.Core.Entities;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace NTTDATA.Application.Interfaces.Repositories
{
    public interface IPersonsRepository
    {
        Task<ResponseBaseList> GetPerson(int ? id);
        Task<ResponseBase> CreatePerson(Cliente cliente);
        Task<ResponseBase> UpdatePerson(Cliente cliente);
        Task<bool> DeletePerson(long id);
    }
}
