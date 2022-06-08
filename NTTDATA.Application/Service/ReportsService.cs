using AutoMapper;
using Microsoft.Extensions.Options;
using NTTDATA.Application.Dtos;
using NTTDATA.Application.Interfaces.Repositories;
using NTTDATA.Application.Interfaces.Services;
using NTTDATA.Core.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NTTDATA.Application.Service
{
    public class ReportsService : IReporteService
    {
        private readonly IReportsRepository _reportsRepository;
        public readonly IMapper _mapper;
        private readonly IOptions<AppSettings> _config;

        public ReportsService(IReportsRepository reportsRepository, IMapper mapper, IOptions<AppSettings> config)
        {
            _reportsRepository = reportsRepository;
            _mapper = mapper;
            _config = config;
        }
        public async Task<ResponseBaseListRepoDTO> GetReports(DateTime? fecha, string numCuenta)
        {
            var request = await _reportsRepository.GetReports(fecha, numCuenta);
            return new ResponseBaseListRepoDTO()
            {
               reportes  = _mapper.Map<List<ReportsDTO>>(request.reportes),
                code = request.code
            };
        }
    }
}
