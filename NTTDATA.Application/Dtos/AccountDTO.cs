using System.Collections.Generic;

#nullable disable

namespace NTTDATA.Application
{
    public  class AccountDTO
    {

        public decimal Id { get; set; }
        public string NumeroCuenta { get; set; }
        public int TipoCuenta { get; set; }
        public decimal SaldoInicial { get; set; }
        public bool Estado { get; set; }
        public decimal ClienteId { get; set; }
    }
   
    public enum TipoCta
    {
        ahorro,
        corriente
    }
    public class ResponseBaseAccountDTO//
    {
        public string code { get; set; }
        public string msg { get; set; }

        public AccountDTO Cuenta  { get; set; }
    }
    public class ResponseBaseListAccountDTO
    {
        public string code { get; set; }
        public string msg { get; set; }

        public List<AccountDTO> Accountdto { get; set; }
        public ResponseBaseListAccountDTO()
        {
            Accountdto = new List<AccountDTO>();
        }
    }
}
