using Acc.Cmd.Domain.Repositories;
using AutoMapper;

namespace Acc.Cmd.Api.Application.Commands
{
    public class GroupsCommandHandler
    {
        protected readonly IMapper _mapper;
        protected readonly IGroupsRepository _GroupsRepository;

        public GroupsCommandHandler(IMapper mapper, IGroupsRepository GroupsRepository)
        {
            _mapper = mapper;
            _GroupsRepository = GroupsRepository;
        }
    }
}