using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NTTDATA.Application.Dtos
{
   public   class ReportsDTO
    {
        public DateTime Fecha { get; set; }
        public string Nombres { get; set; }
        public string NumeroCuenta { get; set; }
        public int TipoCuenta { get; set; }
        public decimal SaldoInicial { get; set; }
        public bool Estado { get; set; }
        public decimal CupoDiario { get; set; }
        public decimal Saldo { get; set; }
    }

    public class ResponseBaseReportDTO
    {
        public string code { get; set; }
        public string msg { get; set; }

        public ReportsDTO? reportes { get; set; }
    }
    public class ResponseBaseListRepoDTO
    {
        public string code { get; set; }
        public string msg { get; set; }

        public List<ReportsDTO> reportes { get; set; }
        public ResponseBaseListRepoDTO()
        {
            reportes = new List<ReportsDTO>();
        }
    }
}
