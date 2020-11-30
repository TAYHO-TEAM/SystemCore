﻿using Acc.Read.Api.ViewModels;
using Acc.Read.Sql.DTOs;
using AutoMapper;

namespace Acc.Read.Api.Infrastructure.Mappings
{
   
    public class GroupFunctionProfile : Profile
    {
        public GroupFunctionProfile()
        { 
            CreateMap<GroupFunctionDTO, GroupFunctionResponseViewModel>().ForMember(target => target.Id, m => m.MapFrom(source => source.Id));
        }
    }
}
