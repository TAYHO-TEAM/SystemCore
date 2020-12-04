using AutoMapper;
using Microsoft.AspNetCore.Http;
using ProjectManager.CMD.Domain.IRepositories;

namespace ProjectManager.CMD.Api.Application.Commands
{
    public class NS_HopDongCommandHandler : BaseCommandHandler
    {
        protected readonly IMapper _mapper;
        protected readonly IHttpContextAccessor _httpContextAccessor;
        protected readonly INS_HopDongRepository _NS_HopDongRepository;

        public NS_HopDongCommandHandler(IMapper mapper, INS_HopDongRepository NS_HopDongRepository,  IHttpContextAccessor httpContextAccessor) : base(httpContextAccessor)
        {
            _mapper = mapper;
            _NS_HopDongRepository = NS_HopDongRepository;
        }
    }
}