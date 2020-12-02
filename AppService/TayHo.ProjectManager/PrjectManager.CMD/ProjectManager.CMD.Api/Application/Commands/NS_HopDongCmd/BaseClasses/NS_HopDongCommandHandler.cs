using AutoMapper;
using ProjectManager.CMD.Domain.IRepositories;

namespace ProjectManager.CMD.Api.Application.Commands
{
    public class NS_HopDongCommandHandler
    {
        protected readonly IMapper _mapper;
        protected readonly INS_HopDongRepository _NS_HopDongRepository;

        public NS_HopDongCommandHandler(IMapper mapper, INS_HopDongRepository NS_HopDongRepository)
        {
            _mapper = mapper;
            _NS_HopDongRepository = NS_HopDongRepository;
        }
    }
}