﻿using Acc.Read.Api.ViewModels;
using Acc.Read.Sql.DTOs;
using AutoMapper;

namespace Acc.Read.Api.Infrastructure.Mappings
{
   
    public class GroupActionPermistionProfile : Profile
    {
        public GroupActionPermistionProfile()
        { 
            CreateMap<GroupActionPermistionDTO, GroupActionPermistionResponseViewModel>().ForMember(target => target.Id, m => m.MapFrom(source => source.Id));
        }
    }
}
