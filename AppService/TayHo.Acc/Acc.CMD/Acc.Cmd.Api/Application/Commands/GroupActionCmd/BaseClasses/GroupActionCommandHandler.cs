using Acc.Cmd.Domain.Repositories;
using AutoMapper;

namespace Acc.Cmd.Api.Application.Commands
{
    public class GroupActionCommandHandler
    {
        protected readonly IMapper _mapper;
        protected readonly IGroupActionRepository _GroupActionRepository;

        public GroupActionCommandHandler(IMapper mapper, IGroupActionRepository GroupActionRepository)
        {
            _mapper = mapper;
            _GroupActionRepository = GroupActionRepository;
        }
    }
}