using Acc.Cmd.Domain.Repositories;
using AutoMapper;

namespace Acc.Cmd.Api.Application.Commands
{
    public class PermistionsCommandHandler
    {
        protected readonly IMapper _mapper;
        protected readonly IPermistionsRepository _PermistionsRepository;

        public PermistionsCommandHandler(IMapper mapper, IPermistionsRepository PermistionsRepository)
        {
            _mapper = mapper;
            _PermistionsRepository = PermistionsRepository;
        }
    }
}