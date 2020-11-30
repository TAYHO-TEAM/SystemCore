using Acc.Cmd.Domain.Repositories;
using AutoMapper;

namespace Acc.Cmd.Api.Application.Commands
{
    public class GroupFunctionCommandHandler
    {
        protected readonly IMapper _mapper;
        protected readonly IGroupFunctionRepository _GroupFunctionRepository;

        public GroupFunctionCommandHandler(IMapper mapper, IGroupFunctionRepository GroupFunctionRepository)
        {
            _mapper = mapper;
            _GroupFunctionRepository = GroupFunctionRepository;
        }
    }
}