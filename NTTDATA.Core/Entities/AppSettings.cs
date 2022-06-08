using System;
using System.Collections.Generic;
using System.Text;

namespace NTTDATA.Core.Entities
{
    public class AppSettings
    {
        public Conexion? ConnectionStrings { get; set; }
        public List<MensajesRetorno>? MensajesApp { get; set; }
        public VTope VTope { get; set; }
    }
    public class Conexion
    {
        public string ISV { get; set; } = "";

    }
    public class VTope
    {
        public string ValorTope { get; set; }

    }
    public class MensajesRetorno
    {
        public string Codigo { get; set; } = "";
        public string Mensaje { get; set; } = "";

    }

    
}
