using AutoMapper;
using ProjectManager.Read.Api.ViewModels;
using ProjectManager.Read.Sql.DTOs.DTO;

namespace ProjectManager.Read.Api.Infrastructure.Mappings
{
    public class NS_LoaiThauProfile : Profile
    {
        public NS_LoaiThauProfile()
        {
            CreateMap<NS_LoaiThauDTO, NS_LoaiThauResponseViewModel>().ForMember(target => target.Id, m => m.MapFrom(source => source.Id));
        }
    }
}
