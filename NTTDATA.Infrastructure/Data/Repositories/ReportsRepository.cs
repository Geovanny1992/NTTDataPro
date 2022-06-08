using Microsoft.Data.SqlClient;
using Microsoft.EntityFrameworkCore;
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
    public class ReportsRepository : IReportsRepository
    {
        private readonly ContextNTTDATA _context;
        public ReportsRepository(ContextNTTDATA context)
        {
            _context = context;
        }

        public async Task<ResponseBaseListRepo> GetReports(DateTime? fecha, string numCuenta)
        {
            string sql = $"EXECUTE dbo.sp_nttdata_transaccones " +
                                        "@opcion," +
                                        "@valor," +
                                        "@NumeroCuenta," +
                                        "@tipo," +
                                        "@Fecha";

            var lst = await _context.reportes.FromSqlRaw(sql, new List<SqlParameter>
            {
                new SqlParameter { ParameterName = "@opcion", SqlDbType = SqlDbType.VarChar, Value = 3 },
                new SqlParameter { ParameterName = "@valor", SqlDbType = SqlDbType.Decimal, Value =0  },
                new SqlParameter { ParameterName = "@NumeroCuenta", SqlDbType = SqlDbType.VarChar, Value =numCuenta},
                new SqlParameter { ParameterName = "@tipo", SqlDbType = SqlDbType.Int, Value =0  },
                  new SqlParameter { ParameterName = "@Fecha", SqlDbType = SqlDbType.DateTime, Value =fecha },
            }.ToArray()).ToListAsync();

            return new ResponseBaseListRepo
            {
                reportes = lst,
                code = "0000"
            };
        }
    }
}
