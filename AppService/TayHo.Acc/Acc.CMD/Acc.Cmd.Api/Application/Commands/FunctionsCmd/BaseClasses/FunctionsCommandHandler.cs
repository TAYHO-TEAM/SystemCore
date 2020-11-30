using Acc.Cmd.Domain.Repositories;
using AutoMapper;

namespace Acc.Cmd.Api.Application.Commands
{
    public class FunctionsCommandHandler
    {
        protected readonly IMapper _mapper;
        protected readonly IFunctionsRepository _FunctionsRepository;

        public FunctionsCommandHandler(IMapper mapper, IFunctionsRepository FunctionsRepository)
        {
            _mapper = mapper;
            _FunctionsRepository = FunctionsRepository;
        }
    }
}