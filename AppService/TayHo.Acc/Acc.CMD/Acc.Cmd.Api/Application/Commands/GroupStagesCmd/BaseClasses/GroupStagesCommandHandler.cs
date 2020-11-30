using Acc.Cmd.Domain.Repositories;
using AutoMapper;

namespace Acc.Cmd.Api.Application.Commands
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