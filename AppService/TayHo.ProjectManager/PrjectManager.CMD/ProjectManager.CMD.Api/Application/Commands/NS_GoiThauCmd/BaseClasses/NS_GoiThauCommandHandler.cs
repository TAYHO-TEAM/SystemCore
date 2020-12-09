using AutoMapper;
using Microsoft.AspNetCore.Http;
using ProjectManager.CMD.Domain.IRepositories;

namespace ProjectManager.CMD.Api.Application.Commands
{
    public class NS_NganSachCommandHandler : BaseCommandHandler
    {
        protected readonly IMapper _mapper; 
        protected readonly IHttpContextAccessor _httpContextAccessor;
        protected readonly INS_NganSachRepository _NS_NganSachRepository;

        public NS_NganSachCommandHandler(IMapper mapper, INS_NganSachRepository NS_NganSachRepository,  IHttpContextAccessor httpContextAccessor) : base(httpContextAccessor)
        {
            _mapper = mapper;
            _NS_NganSachRepository = NS_NganSachRepository;
            _httpContextAccessor = httpContextAccessor;
        }
    }
}