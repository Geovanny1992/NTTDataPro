using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;


#nullable disable

namespace NTTDATA.Core.Entities
{
    public partial class Cuenta
    {
        public Cuenta()
        {
            Movimientos = new HashSet<Movimiento>();
        }
        [Key]
        public decimal Id { get; set; }
        public string NumeroCuenta { get; set; }
        public int TipoCuenta { get; set; }
        public decimal SaldoInicial { get; set; }
        public bool Estado { get; set; }
        public decimal ClienteId { get; set; }

        public virtual Cliente Cliente { get; set; }
        public virtual ICollection<Movimiento> Movimientos { get; set; }
    }

    public class ResponseBaseAccount
    {
        public string code { get; set; }
        public string msg { get; set; }

        public Cuenta Account { get; set; }
    }
    public class ResponseBaseAccountList
    {
        public string code { get; set; }
        public string msg { get; set; }

        public List<Cuenta> Account { get; set; }
        public ResponseBaseAccountList()
        {
            Account = new List<Cuenta>();
        }
    }
    public enum TipoCta
    {
        ahorro,
        corriente
    }
}
