using AutoMapper;
using Microsoft.AspNetCore.Http;
using ProjectManager.CMD.Domain.IRepositories;

namespace ProjectManager.CMD.Api.Application.Commands
{
    public class NS_NganSachDetailCommandHandler : BaseCommandHandler
    {
        protected readonly IMapper _mapper; 
        protected readonly IHttpContextAccessor _httpContextAccessor;
        protected readonly INS_NganSachDetailRepository _NS_NganSachDetailRepository;

        public NS_NganSachDetailCommandHandler(IMapper mapper, INS_NganSachDetailRepository NS_NganSachDetailRepository,  IHttpContextAccessor httpContextAccessor) : base(httpContextAccessor)
        {
            _mapper = mapper;
            _NS_NganSachDetailRepository = NS_NganSachDetailRepository;
            _httpContextAccessor = httpContextAccessor;
        }
    }
}