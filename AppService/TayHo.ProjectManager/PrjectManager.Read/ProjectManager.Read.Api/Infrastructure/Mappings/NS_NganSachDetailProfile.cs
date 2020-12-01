using AutoMapper;
using ProjectManager.Read.Api.ViewModels;
using ProjectManager.Read.Sql.DTOs.DTO;

namespace ProjectManager.Read.Api.Infrastructure.Mappings
{
    public class NS_NganSachDetailProfile : Profile
    {
        public NS_NganSachDetailProfile()
        {
            CreateMap<NS_NganSachDetailDTO, NS_NganSachDetailResponseViewModel>().ForMember(target => target.Id, m => m.MapFrom(source => source.Id));
        }
    }
}
