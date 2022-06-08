using System;
using System.Collections.Generic;
using System.Text;

namespace NTTDATA.Core.Entities
{
    public class Resulset
    {
        public string codError { get; set; }
        public string mensaje { get; set; }
        
    }
    public class Reports
    {
        public DateTime Fecha { get; set; }
        public string Nombres { get; set; } = "";
        public string NumeroCuenta { get; set; } = "";
        public int TipoCuenta { get; set; }
        public decimal SaldoInicial { get; set; }
        public bool Estado { get; set; }
        public decimal CupoDiario { get; set; }
        public decimal Saldo { get; set; }
    }

    public class ResponseBaseReport
    {
        public string code { get; set; } = "";
        public string msg { get; set; } = "";

        public Reports? reportes { get; set; }
    }
    public class ResponseBaseListRepo
    {
        public string code { get; set; }
        public string msg { get; set; }

        public List<Reports> reportes { get; set; }
        public ResponseBaseListRepo()
        {
            reportes = new List<Reports>();
        }
    }
}
