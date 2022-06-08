
using System;
using System.Collections.Generic;

#nullable disable

namespace NTTDATA.Application
{
    public class MovementDTO
    {            
        public string TipoMovimiento { get; set; }
        public int TipoCta { get; set; }
        public string NumeroCuenta { get; set; }
        public decimal Valor { get; set; }           

    }

    public class ResulsetDto
    {
        public string codError { get; set; }
        public string mensaje { get; set; }
        public List<DetalleMovDTO>? detalleMov { get; set; }
        
    }
    public class DetalleMovDTO
    {
        public DateTime Fecha { get; set; }
        public string Cliente { get; set; }   
        public string NumeroCuenta { get; set; }
        public int TipoCuenta { get; set; }
        public string TipoMovimiento { get; set; }        
        public decimal SaldoDisponible { get; set; }
        public decimal saldoInicial { get; set; }
        public bool Estado { get; set; }


    }

}
