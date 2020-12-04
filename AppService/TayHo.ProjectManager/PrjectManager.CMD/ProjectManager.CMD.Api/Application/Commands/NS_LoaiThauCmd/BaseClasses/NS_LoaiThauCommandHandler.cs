using AutoMapper;
using Microsoft.AspNetCore.Http;
using ProjectManager.CMD.Domain.IRepositories;

namespace ProjectManager.CMD.Api.Application.Commands
{
    public class NS_LoaiThauCommandHandler : BaseCommandHandler
    {
        protected readonly IMapper _mapper; 
        protected readonly IHttpContextAccessor _httpContextAccessor;
        protected readonly INS_LoaiThauRepository _NS_LoaiThauRepository;

        public NS_LoaiThauCommandHandler(IMapper mapper, INS_LoaiThauRepository NS_LoaiThauRepository,  IHttpContextAccessor httpContextAccessor) : base(httpContextAccessor)
        {
            _mapper = mapper;
            _NS_LoaiThauRepository = NS_LoaiThauRepository;
        }
    }
}