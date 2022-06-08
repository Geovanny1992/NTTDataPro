using Microsoft.EntityFrameworkCore;
using NTTDATA.Application.Interfaces.Repositories;
using NTTDATA.Core.Entities;
using NTTDATA.Infrastructure.Data.Context;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NTTDATA.Infrastructure.Data.Repositories
{
    public class AccountRepository : IAccountRepository
    {
        private readonly ContextNTTDATA _context;

        public AccountRepository(ContextNTTDATA context)
        {
            _context = context;

        }
        public async Task<ResponseBaseAccount> CreateUpdateAccount(Cuenta account)
        {
            #region Crear Cuentas
  

            if (account.Id == 0)
            {
                if (_context.Cuentas.Where(x => x.NumeroCuenta == account.NumeroCuenta).Count() > 0)
                {
                    return new ResponseBaseAccount()
                    {
                        Account = null,
                        code = "0023"
                    };
                }
                _context.Add(account);
                var dat = await _context.SaveChangesAsync();
                if (dat > 0)
                {
                    var request = _context.Cuentas.OrderByDescending(u => u.Id).FirstOrDefault();
                    return new ResponseBaseAccount()
                    {
                        Account = _context.Cuentas.OrderByDescending(u => u.Id).FirstOrDefault(),
                        code = "0010"
                    };
                }
                return new ResponseBaseAccount()
                {
                    Account = null,
                    code = "0011"
                };
            }
            #endregion

            #region Actualiza cuentas


            if (_context.Cuentas.Where(x => x.Id == account.Id).Count() > 0 )
            {
                _context.ChangeTracker.Clear();
                _context.Update(account);
                var dat = await _context.SaveChangesAsync();
                if (dat > 0)
                {
                    var request = _context.Cuentas.Where(x => x.Id == account.Id).ToList();

                 Cuenta ob = null;
                    request.ForEach(x =>
                    {
                        ob = new Cuenta()
                        {
                            Id = x.Id,
                            Estado = false,
                            NumeroCuenta = x.NumeroCuenta,
                            ClienteId = x.ClienteId,
                            SaldoInicial = x.SaldoInicial,
                            TipoCuenta = x.TipoCuenta,               
                        };
                    });
                    return new ResponseBaseAccount()
                    {
                        Account = ob,
                        code = "0010"
                    };
                }
                return new ResponseBaseAccount()
                {
                    Account = null,
                    code = "0011"
                };
            }
            else
            {
                return new ResponseBaseAccount()
                {
                    Account = null,
                    code = "0023"
                };
            }
            #endregion
        }

        public async Task<bool> DeleteAccount(long id)
        {
            var id_ = Convert.ToDecimal(id);
            if (_context.Cuentas.Where(x => x.Id == id && x.Estado == true).Count() > 0)
            {
                var person = await _context.Cuentas.Where(x => x.Id == id).ToListAsync();

               
                Cuenta account = null;
                person.ForEach(x =>
                {
                    account = new Cuenta()
                    {
                        Id = x.Id,
                        ClienteId = x.ClienteId,
                        Estado = false,                        
                        NumeroCuenta = x.NumeroCuenta,
                        SaldoInicial = x.SaldoInicial,
                        TipoCuenta = x.TipoCuenta

                    };
                });
                _context.ChangeTracker.Clear();
                _context.Update(account);
                var response = await _context.SaveChangesAsync();
                if (response > 0)
                    return true;
                else
                    return false;
            }
            return true;
        }

        public async Task<ResponseBaseAccountList> GetAccount(int? id)
        {
            ResponseBaseAccountList _baseList = new ResponseBaseAccountList();
            if (id == null)
            {
                var data = await (from m in _context.Cuentas
                                  where m.Estado == true
                                  select m
                    ).ToListAsync();
                if (data.Count > 0)
                {
                    _baseList.code = "0000";
                    _baseList.Account = data;
                    return _baseList;
                }
            }
            else
            {
                var data = await (_context.Cuentas.Where(s => s.ClienteId == id && s.Estado == true)
                    ).ToListAsync();
                if (data.Count > 0)
                {
                    _baseList.code = "0000";
                    _baseList.Account = data;
                    return _baseList;
                }
            }

            return _baseList;
        }
    }
}
