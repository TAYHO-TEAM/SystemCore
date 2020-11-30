using Acc.Cmd.Domain.Repositories;
using AutoMapper;

namespace Acc.Cmd.Api.Application.Commands
{
    public class GroupAccountCommandHandler
    {
        protected readonly IMapper _mapper;
        protected readonly IGroupAccountRepository _GroupAccountRepository;

        public GroupAccountCommandHandler(IMapper mapper, IGroupAccountRepository GroupAccountRepository)
        {
            _mapper = mapper;
            _GroupAccountRepository = GroupAccountRepository;
        }
    }
}