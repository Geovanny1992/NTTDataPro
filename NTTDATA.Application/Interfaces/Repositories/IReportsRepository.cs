using NTTDATA.Core.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NTTDATA.Application.Interfaces.Repositories
{
   public interface IReportsRepository
    {
        Task<ResponseBaseListRepo> GetReports(DateTime? fecha , string numCuenta);
    }
}
