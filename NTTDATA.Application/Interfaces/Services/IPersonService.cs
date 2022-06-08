using NTTDATA.Core.Entities;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace NTTDATA.Application.Interfaces.Services
{
    public interface IPersonService
    {
        Task<ResponseDTOList> GetConsultaCasosCliente(int ? id);       
        Task<ResponseDTO> CreatePerson(ClienteDTO clienteDTO);
        Task<ResponseDTO> UpdatePerson(ClienteDTO clienteDTO);
        Task<bool> DeletePerson(long id);
    }
}
