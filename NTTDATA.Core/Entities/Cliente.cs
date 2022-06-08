using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
#nullable disable

namespace NTTDATA.Core.Entities
{
    public partial class Cliente
    {
        public Cliente()
        {
            Cuenta = new HashSet<Cuenta>();
        }
        [Key]  
        public decimal Id { get; set; }
        public string Contrasena { get; set; }
        public bool Estado { get; set; }
        public string Nombres { get; set; }
        public int Genero { get; set; }
        public DateTime FechaNacimiento { get; set; }
        public string Identificacion { get; set; }
        public string Direccion { get; set; }
        public string Telefono { get; set; }

        public virtual ICollection<Cuenta> Cuenta { get; set; }
    }
    public enum GenerosBase
    {
        masculino,
        femenino
    }
    public class ResponseBase
    {
        public string code { get; set; }
        public string msg { get; set; }

        public Cliente cliente { get; set; }
    }
    public class ResponseBaseList
    {
        public string code { get; set; }
        public string msg { get; set; }

        public List<Cliente> cliente { get; set; }
        public ResponseBaseList()
        {
            cliente = new List<Cliente>();
        }
    }
}
