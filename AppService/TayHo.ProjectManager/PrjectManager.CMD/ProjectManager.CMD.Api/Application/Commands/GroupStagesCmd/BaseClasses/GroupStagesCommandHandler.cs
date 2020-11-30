using AutoMapper;
using ProjectManager.CMD.Domain.IRepositories;

namespace ProjectManager.CMD.Api.Application.Commands
{
    public class GroupStagesCommandHandler
    {
        protected readonly IMapper _mapper;
        protected readonly IGroupStagesRepository _GroupStagesRepository;

        public GroupStagesCommandHandler(IMapper mapper, IGroupStagesRepository GroupStagesRepository)
        {
            _mapper = mapper;
            _GroupStagesRepository = GroupStagesRepository;
        }
    }
}