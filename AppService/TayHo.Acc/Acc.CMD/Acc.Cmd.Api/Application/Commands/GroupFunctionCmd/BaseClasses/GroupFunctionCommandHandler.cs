using Acc.Cmd.Domain.Repositories;
using AutoMapper; using Microsoft.AspNetCore.Http;

namespace Acc.Cmd.Api.Application.Commands
{
    public class GroupFunctionCommandHandler: BaseCommandHandler
    {
        protected readonly IMapper _mapper; protected readonly IHttpContextAccessor _httpContextAccessor;
        protected readonly IGroupFunctionRepository _GroupFunctionRepository;

        public GroupFunctionCommandHandler(IMapper mapper,  IHttpContextAccessor httpContextAccessor, IGroupFunctionRepository GroupFunctionRepository) : base(httpContextAccessor)
        {
            _mapper = mapper;
            _GroupFunctionRepository = GroupFunctionRepository;
        }
    }
}