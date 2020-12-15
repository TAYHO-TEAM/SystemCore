using AutoMapper;
using ProjectManager.Read.Api.ViewModels;
using ProjectManager.Read.Sql.DTOs.DTO;

namespace ProjectManager.Read.Api.Infrastructure.Mappings
{
    public class ResponseRegistProfile : Profile
    {
        public ResponseRegistProfile()
        {
        //    CreateMap<RequestRegistDTO, RequestRegistResponseViewModel>().ForMember(target => target.Id, m => m.MapFrom(source => source.Id));
        //    CreateMap<RequestRegistDTO, ResponseRegistResponseViewModel>().ForMember(target => target.Id, m => m.MapFrom(source => source.Id));
        }
    }
}
