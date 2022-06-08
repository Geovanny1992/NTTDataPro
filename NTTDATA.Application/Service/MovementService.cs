using AutoMapper;
using Microsoft.Extensions.Options;
using NTTDATA.Application.Interfaces.Repositories;
using NTTDATA.Application.Interfaces.Services;
using NTTDATA.Core.Entities;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace NTTDATA.Application.Service
{
    public class MovementService : IMovementService
    {
        private readonly IMovementRepository _movimientoRepository;
        public readonly IMapper _mapper;
        private readonly IOptions<AppSettings> _config;
        public MovementService(IMovementRepository movimientoRepository, IMapper mapper, IOptions<AppSettings> config)
        {
            _movimientoRepository = movimientoRepository;
            _mapper = mapper;
            _config = config;
        }
        public async Task<ResulsetDto> GenerateProcess(MovementDTO mov)
        {
            var lst=new List<DetalleMovDTO>();

            var valor = _config.Value.VTope.ValorTope;          
            if (mov.Valor >Convert.ToDecimal(valor))
            {
                return new ResulsetDto()
                {
                    codError = "0003",
                    detalleMov = new List<DetalleMovDTO>()
                };
            }
            
            var resl1 = _mapper.Map<MovementBase>(mov);
            var request = await _movimientoRepository.GetDetailsMov(resl1);

            request.detalleMov.ForEach(x =>
            {

                lst.Add(new DetalleMovDTO()
                {
                    Cliente = x.Nombres,
                    TipoMovimiento=x.TipoCuenta==1?"Débito":"Crédito",
                    Estado=x.Estado,
                    Fecha=x.Fecha,
                    NumeroCuenta=x.NumeroCuenta,
                    SaldoDisponible=x.SaldoInicial,
                    saldoInicial=x.Saldo,
                    TipoCuenta=x.TipoCuenta
                });
            });

            return new ResulsetDto()
            {
                detalleMov = new List<DetalleMovDTO>(lst),
                codError = request.codError,
            };
            
        }
    }
}
