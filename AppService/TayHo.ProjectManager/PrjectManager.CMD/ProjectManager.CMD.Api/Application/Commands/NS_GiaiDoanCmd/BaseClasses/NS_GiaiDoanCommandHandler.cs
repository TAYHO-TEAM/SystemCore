using AutoMapper;
using ProjectManager.CMD.Domain.IRepositories;

namespace ProjectManager.CMD.Api.Application.Commands
{
    public class NS_GiaiDoanCommandHandler
    {
        protected readonly IMapper _mapper;
        protected readonly INS_GiaiDoanRepository _NS_GiaiDoanRepository;

        public NS_GiaiDoanCommandHandler(IMapper mapper, INS_GiaiDoanRepository NS_GiaiDoanRepository)
        {
            _mapper = mapper;
            _NS_GiaiDoanRepository = NS_GiaiDoanRepository;
        }
    }
}