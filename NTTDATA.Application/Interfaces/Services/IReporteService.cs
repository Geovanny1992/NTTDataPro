using NTTDATA.Application.Dtos;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NTTDATA.Application.Interfaces.Services
{
    public interface IReporteService
    {
        Task<ResponseBaseListRepoDTO> GetReports(DateTime? fecha, string numCuenta);
    }
}
