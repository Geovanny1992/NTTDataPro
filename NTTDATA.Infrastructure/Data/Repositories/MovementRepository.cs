using Microsoft.Data.SqlClient;
using Microsoft.EntityFrameworkCore;
using NTTDATA.Application;
using NTTDATA.Application.Interfaces.Repositories;
using NTTDATA.Core.Entities;
using NTTDATA.Infrastructure.Data.Context;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NTTDATA.Infrastructure.Data.Repositories
{
    public class MovementRepository : IMovementRepository
    {
        private readonly ContextNTTDATA _context;
        private readonly IAccountRepository _accountRepository;
        public MovementRepository(ContextNTTDATA context, IAccountRepository accountRepository)
        {
            _context = context;
            _accountRepository = accountRepository;
        }

        public Task<Resulset> GenerateProcessMov(MovementBase mov)
        {
            throw new NotImplementedException();
        }

        public async Task<ResulsetBase> GetDetailsMov(MovementBase mov)
        {
            var list = new List<DetalleMov>();
            string opcion = "";
            //débito y crédito 
            if (mov.TipoMovimiento.Equals("Debito"))
                opcion = "1";
            else
                opcion = "2";

            string sql = $"EXECUTE dbo.sp_nttdata_transaccones " +
                                         "@opcion," +
                                         "@valor," +
                                         "@NumeroCuenta," +
                                         "@tipo";

            Resulset resulset = null;
            var lst = await _context.resulsets.FromSqlRaw(sql, new List<SqlParameter>
            {
                new SqlParameter { ParameterName = "@opcion", SqlDbType = SqlDbType.VarChar, Value = opcion  },
                new SqlParameter { ParameterName = "@valor", SqlDbType = SqlDbType.Decimal, Value =mov.Valor  },
                new SqlParameter { ParameterName = "@NumeroCuenta", SqlDbType = SqlDbType.VarChar, Value =mov.NumeroCuenta},
                new SqlParameter { ParameterName = "@tipo", SqlDbType = SqlDbType.Int, Value =mov.TipoCta  },

            }.ToArray()).ToListAsync();

            lst.ForEach(x =>
            {
                resulset = new Resulset()
                {
                    codError = x.codError,
                    mensaje = x.mensaje
                };
            });

            if (resulset.codError == "000")
            {
                list = await _context.detalleMovs.FromSqlRaw(sql, new List<SqlParameter>
            {
                new SqlParameter { ParameterName = "@opcion", SqlDbType = SqlDbType.VarChar, Value = 4  },
                new SqlParameter { ParameterName = "@valor", SqlDbType = SqlDbType.Decimal, Value =mov.Valor  },
                new SqlParameter { ParameterName = "@NumeroCuenta", SqlDbType = SqlDbType.VarChar, Value =mov.NumeroCuenta},
                new SqlParameter { ParameterName = "@tipo", SqlDbType = SqlDbType.Int, Value =mov.TipoCta  },

            }.ToArray()).ToListAsync();

            }
            return new ResulsetBase()
            {
                codError= resulset.codError,
                mensaje= resulset.mensaje,
                detalleMov=new List<DetalleMov>(list)
            };
        }

    }
}
