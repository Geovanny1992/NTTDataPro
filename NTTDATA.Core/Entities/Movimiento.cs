using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

#nullable disable

namespace NTTDATA.Core.Entities
{
    public partial class Movimiento
    {
        [Key]       
        public decimal Id { get; set; }
        public DateTime? Fecha { get; set; }
        public int TipoMovimiento { get; set; }
        public decimal Valor { get; set; }
        public decimal Saldo { get; set; }
        public decimal CuentaId { get; set; }
        public decimal CupoDiario { get; set; }

        public virtual Cuenta Cuenta { get; set; }
    }

    public class MovementBase
    {
        public string TipoMovimiento { get; set; }
        public int TipoCta { get; set; }
        public string NumeroCuenta { get; set; }
        public decimal Valor { get; set; }

    }


    public class DetalleMov
    {
        public DateTime Fecha { get; set; }
        public string Nombres { get; set; }
        public string NumeroCuenta { get; set; }
        public int TipoCuenta { get; set; }
        public decimal SaldoInicial { get; set; }
        public decimal Saldo { get; set; }
        public bool Estado { get; set; }

    }

    public class ResulsetBase
    {
        public string codError { get; set; }
        public string mensaje { get; set; }
        public List<DetalleMov>? detalleMov { get; set; }

    }


}
