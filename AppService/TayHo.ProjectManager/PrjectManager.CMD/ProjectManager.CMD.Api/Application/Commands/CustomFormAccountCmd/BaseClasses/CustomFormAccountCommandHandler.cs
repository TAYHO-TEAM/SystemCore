using ProjectManager.CMD.Domain.IRepositories;
using AutoMapper;
using Microsoft.AspNetCore.Http;
using Services.Common.Security;

namespace ProjectManager.CMD.Api.Application.Commands
{
    public class CustomFormAccountCommandHandler : BaseCommandHandler
    {
        protected readonly IMapper _mapper;
        protected readonly IHttpContextAccessor _httpContextAccessor;
        protected readonly ICustomFormAccountRepository _customFormAccountRepository;

        public CustomFormAccountCommandHandler(IMapper mapper, IHttpContextAccessor httpContextAccessor, ICustomFormAccountRepository CustomFormAccountRepository ) : base (httpContextAccessor)
        {
            _mapper = mapper;
            _httpContextAccessor = httpContextAccessor;
            _customFormAccountRepository = CustomFormAccountRepository;
        }
    }
}
