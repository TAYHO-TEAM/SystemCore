using AutoMapper;
using ProjectManager.CMD.Domain.IRepositories;

namespace ProjectManager.CMD.Api.Application.Commands
{
    public class NS_NhomChiPhiCommandHandler
    {
        protected readonly IMapper _mapper;
        protected readonly INS_NhomChiPhiRepository _NS_NhomChiPhiRepository;

        public NS_NhomChiPhiCommandHandler(IMapper mapper, INS_NhomChiPhiRepository NS_NhomChiPhiRepository)
        {
            _mapper = mapper;
            _NS_NhomChiPhiRepository = NS_NhomChiPhiRepository;
        }
    }
}