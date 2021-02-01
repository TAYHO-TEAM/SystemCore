﻿using AutoMapper;
using ProjectManager.Read.Api.ViewModels;
using ProjectManager.Read.Sql.DTOs.DTO;

namespace ProjectManager.Read.Api.Infrastructure.Mappings
{
    public class PlanMasterProfile : Profile
    {
        public PlanMasterProfile()
        {
            CreateMap<PlanMasterDTO, PlanMasterResponseViewModel>().ForMember(target => target.Id, m => m.MapFrom(source => source.Id));
        }
    }
}
