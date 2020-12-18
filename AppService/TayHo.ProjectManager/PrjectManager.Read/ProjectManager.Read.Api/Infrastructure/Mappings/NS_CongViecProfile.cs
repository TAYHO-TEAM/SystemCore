﻿using AutoMapper;
using ProjectManager.Read.Api.ViewModels;
using ProjectManager.Read.Sql.DTOs.DTO;

namespace ProjectManager.Read.Api.Infrastructure.Mappings
{
    public class NS_CongViecProfile : Profile
    {
        public NS_CongViecProfile()
        {
            CreateMap<NS_CongViecDTO, NS_CongViecResponseViewModel>().ForMember(target => target.Id, m => m.MapFrom(source => source.Id));
        }
    }
}
