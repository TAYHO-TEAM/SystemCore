﻿using AutoMapper;
using ProjectManager.Read.Api.ViewModels;
using ProjectManager.Read.Sql.DTOs.DTO;

namespace ProjectManager.Read.Api.Infrastructure.Mappings
{
    public class RequestDetailProfile : Profile
    {
        public RequestDetailProfile()
        {
            CreateMap<RequestDetailDTO, RequestDetailResponseViewModel>().ForMember(target => target.Id, m => m.MapFrom(source => source.Id));
        }
    }
}
