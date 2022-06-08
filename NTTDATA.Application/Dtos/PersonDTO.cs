using System;
using System.Collections.Generic;

#nullable disable

namespace NTTDATA.Application
{

    #region Entidades para el ingreso y atualización

    public class ClienteDTO : PersonDTO
    {
        public string Contrasena { get; set; }
        public bool Estado { get; set; }

    }
    public class PersonDTO
    {
        public decimal Id { get; set; }
        public string Nombres { get; set; }
        public int Genero { get; set; }     
        public DateTime FechaNacimiento { get; set; }
        public string Identificacion { get; set; }
        public string Direccion { get; set; }
        public string Telefono { get; set; }
       
    }
   
    #endregion

    #region Entidades para la consulta
    public class ClienteRequestDTO : PersonaRequestDTO 
    {
        public string Contrasena { get; set; }
        public bool Estado { get; set; }

    }

    public class PersonaRequestDTO
    {
        public decimal Id { get; set; }
        public string Nombres { get; set; }
        public string Direccion { get; set; }
        public string Telefono { get; set; }

    }
    #endregion

    #region Entidades de salida json
    public class ResponseDTO
    {
        public string code { get; set; }
        public string msg { get; set; }

        public ClienteRequestDTO clienteDTO { get; set; }


    }

    public class ResponseDTOList
    {
        public string code { get; set; }
        public string msg { get; set; }

        public List<ClienteRequestDTO> clienteDTO { get; set; }
        public ResponseDTOList()
        {
            clienteDTO = new List<ClienteRequestDTO>();
        }

    }
    #endregion


}
