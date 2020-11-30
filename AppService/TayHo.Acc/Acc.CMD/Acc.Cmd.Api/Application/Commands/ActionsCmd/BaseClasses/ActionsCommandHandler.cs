using Acc.Cmd.Domain.Repositories;
using AutoMapper;

namespace Acc.Cmd.Api.Application.Commands
{
    public class ActionsCommandHandler
    {
        protected readonly IMapper _mapper;
        protected readonly IActionsRepository _actionsRepository;

        public ActionsCommandHandler(IMapper mapper, IActionsRepository ActionsRepository)
        {
            _mapper = mapper;
            _actionsRepository = ActionsRepository;
        }
    }
}