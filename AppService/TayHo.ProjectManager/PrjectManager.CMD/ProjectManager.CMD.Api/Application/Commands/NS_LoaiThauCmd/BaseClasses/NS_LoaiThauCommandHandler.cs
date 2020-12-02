using AutoMapper;
using ProjectManager.CMD.Domain.IRepositories;

namespace ProjectManager.CMD.Api.Application.Commands
{
    public class NS_LoaiThauCommandHandler
    {
        protected readonly IMapper _mapper;
        protected readonly INS_LoaiThauRepository _NS_LoaiThauRepository;

        public NS_LoaiThauCommandHandler(IMapper mapper, INS_LoaiThauRepository NS_LoaiThauRepository)
        {
            _mapper = mapper;
            _NS_LoaiThauRepository = NS_LoaiThauRepository;
        }
    }
}