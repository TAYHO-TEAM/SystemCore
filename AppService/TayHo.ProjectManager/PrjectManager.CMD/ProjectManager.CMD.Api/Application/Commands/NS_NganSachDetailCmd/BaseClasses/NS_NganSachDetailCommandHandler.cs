using AutoMapper;
using ProjectManager.CMD.Domain.IRepositories;

namespace ProjectManager.CMD.Api.Application.Commands
{
    public class NS_NganSachDetailCommandHandler
    {
        protected readonly IMapper _mapper;
        protected readonly INS_NganSachDetailRepository _NS_NganSachDetailRepository;

        public NS_NganSachDetailCommandHandler(IMapper mapper, INS_NganSachDetailRepository NS_NganSachDetailRepository)
        {
            _mapper = mapper;
            _NS_NganSachDetailRepository = NS_NganSachDetailRepository;
        }
    }
}