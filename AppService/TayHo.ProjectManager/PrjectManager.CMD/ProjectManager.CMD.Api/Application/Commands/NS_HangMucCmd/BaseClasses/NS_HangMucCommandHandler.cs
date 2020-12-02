using AutoMapper;
using ProjectManager.CMD.Domain.IRepositories;

namespace ProjectManager.CMD.Api.Application.Commands
{
    public class NS_HangMucCommandHandler
    {
        protected readonly IMapper _mapper;
        protected readonly INS_HangMucRepository _NS_HangMucRepository;

        public NS_HangMucCommandHandler(IMapper mapper, INS_HangMucRepository NS_HangMucRepository)
        {
            _mapper = mapper;
            _NS_HangMucRepository = NS_HangMucRepository;
        }
    }
}