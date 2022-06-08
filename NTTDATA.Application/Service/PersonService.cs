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
    public class PersonService : IPersonService
    {
        private readonly IPersonsRepository _personaRepository;
        public readonly IMapper _mapper;
        private readonly IOptions<AppSettings> _config;
        public PersonService(IPersonsRepository personaRepository, IMapper mapper, IOptions<AppSettings> config)
        {
            _personaRepository = personaRepository;
            _mapper = mapper;
            _config = config;
        }

        public async Task<ResponseDTOList> GetConsultaCasosCliente(int? id)
        {
           
            var valor = _config.Value.VTope.ValorTope;
            var request = await _personaRepository.GetPerson(id);
            return new ResponseDTOList()
            {
                clienteDTO = _mapper.Map<List<ClienteRequestDTO>>(request.cliente),
                code = request.code
            };
        }

        public async Task<ResponseDTO> CreatePerson(ClienteDTO clienteDTO)
        {
            try
            {
                if (clienteDTO.Identificacion.Length <10 || clienteDTO.Identificacion.Length > 13)
                {
                    return new ResponseDTO()
                    {
                        clienteDTO = null,
                        code = "0022"
                    };
                }
               

 
                    var resul = _mapper.Map<Cliente>(clienteDTO);
                    var request = await _personaRepository.CreatePerson(resul);
                    return new ResponseDTO()
                    {
                        clienteDTO = _mapper.Map<ClienteRequestDTO>(request.cliente),
                        code = request.code
                    };
                              
            }
            catch (Exception e)
            {
                throw e;
            }                      
        }

        public async Task<ResponseDTO> UpdatePerson(ClienteDTO clienteDTO)
        {
            try
            {
                if (clienteDTO.Identificacion.Length < 10 || clienteDTO.Identificacion.Length > 13)
                {
                    return new ResponseDTO()
                    {
                        clienteDTO = null,
                        code = "0022"
                    };
                }                

                var resul = _mapper.Map<Cliente>(clienteDTO);
                var request = await _personaRepository.UpdatePerson(resul);
                return new ResponseDTO()
                {
                    clienteDTO = _mapper.Map<ClienteRequestDTO>(request.cliente),
                    code = request.code
                };

            }
            catch (Exception e)
            {
                throw e;
            }
        }

        public async Task<bool> DeletePerson(long id)
        {
            try
            {
                if (id > 0)
                {
                    var request = await _personaRepository.DeletePerson(id);
                    return request ? true : false;
                }
                return true;
            }
            catch (Exception e)
            {
                throw e;
            }
        }
    }
}
