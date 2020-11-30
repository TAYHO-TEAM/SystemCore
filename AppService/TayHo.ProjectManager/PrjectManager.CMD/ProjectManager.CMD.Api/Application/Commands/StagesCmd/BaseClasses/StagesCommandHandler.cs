using AutoMapper;
using ProjectManager.CMD.Domain.IRepositories;

namespace ProjectManager.CMD.Api.Application.Commands
{
    public class StagesCommandHandler
    {
        protected readonly IMapper _mapper;
        protected readonly IStagesRepository _StagesRepository;

        public StagesCommandHandler(IMapper mapper, IStagesRepository StagesRepository)
        {
            _mapper = mapper;
            _StagesRepository = StagesRepository;
        }
    }
}