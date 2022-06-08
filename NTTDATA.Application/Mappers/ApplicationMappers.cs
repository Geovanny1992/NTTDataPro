using System;
using System.Collections.Generic;
using System.Text;
using AutoMapper;
using NTTDATA.Application.Dtos;
using NTTDATA.Core.Entities;

namespace NTTDATA.Application.Mappers
{
    public class ApplicationMappers:Profile
    {
        public ApplicationMappers()
        {
            CreateMap<ClienteRequestDTO, Cliente>().ReverseMap();
            CreateMap<ClienteDTO, Cliente>().ReverseMap();
            CreateMap<MovementDTO, Movimiento>().ReverseMap();
            CreateMap<AccountDTO, Cuenta>().ReverseMap();
            CreateMap<ResponseDTO, ResponseBase>().ReverseMap();
            CreateMap<ResponseDTOList, ResponseBaseList>().ReverseMap();
            CreateMap<Movimiento, MovementDTO>().ReverseMap();
            CreateMap<MovementDTO, Movimiento>().ReverseMap();
            CreateMap<MovementBase, MovementDTO>().ReverseMap();
            CreateMap<MovementDTO, MovementBase>().ReverseMap();
            CreateMap<Movimiento, MovementBase>().ReverseMap();                      
            CreateMap<ResponseBaseAccountList, ResponseBaseListAccountDTO>().ReverseMap();
            CreateMap<ResponseBaseListAccountDTO, ResponseBaseAccountList>().ReverseMap();
            CreateMap<ResponseBaseListRepo, ResponseBaseReport>().ReverseMap();
            CreateMap<ResponseBaseReport, ResponseBaseListRepo>().ReverseMap();
            CreateMap<Cuenta, AccountDTO>().ReverseMap();
            CreateMap<Reports, ReportsDTO>().ReverseMap();
            CreateMap<ReportsDTO, Reports>().ReverseMap();




        }
    }
}
