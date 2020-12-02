using AutoMapper;
using ProjectManager.CMD.Domain.IRepositories;

namespace ProjectManager.CMD.Api.Application.Commands
{
    public class NS_NganSachCommandHandler
    {
        protected readonly IMapper _mapper;
        protected readonly INS_NganSachRepository _NS_NganSachRepository;

        public NS_NganSachCommandHandler(IMapper mapper, INS_NganSachRepository NS_NganSachRepository)
        {
            _mapper = mapper;
            _NS_NganSachRepository = NS_NganSachRepository;
        }
    }
}