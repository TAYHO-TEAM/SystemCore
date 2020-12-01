﻿using Acc.Read.Api.ViewModels;
using Acc.Read.Sql.DTOs;
using AutoMapper;

namespace Acc.Read.Api.Infrastructure.Mappings
{
   
    public class FunctionsProfile : Profile
    {
        public FunctionsProfile()
        { 
            CreateMap<FunctionsDTO, FunctionsResponseViewModel>().ForMember(target => target.Id, m => m.MapFrom(source => source.Id));
        }
    }
}