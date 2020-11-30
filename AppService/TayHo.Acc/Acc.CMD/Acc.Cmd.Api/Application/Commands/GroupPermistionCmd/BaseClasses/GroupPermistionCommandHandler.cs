using Acc.Cmd.Domain.Repositories;
using AutoMapper;

namespace Acc.Cmd.Api.Application.Commands
{
    public class GroupPermistionCommandHandler
    {
        protected readonly IMapper _mapper;
        protected readonly IGroupPermistionRepository _GroupPermistionRepository;

        public GroupPermistionCommandHandler(IMapper mapper, IGroupPermistionRepository GroupPermistionRepository)
        {
            _mapper = mapper;
            _GroupPermistionRepository = GroupPermistionRepository;
        }
    }
}