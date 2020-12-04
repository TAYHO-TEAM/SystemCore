using ProjectManager.CMD.Domain.IRepositories;
using AutoMapper;
using Microsoft.AspNetCore.Http;

namespace ProjectManager.CMD.Api.Application.Commands
{
    public class ContractorInfoCommandHandler : BaseCommandHandler
    {
        protected readonly IMapper _mapper;
        protected readonly IHttpContextAccessor _httpContextAccessor;
        protected readonly IContractorInfoRepository _ContractorInfoRepository;

        public ContractorInfoCommandHandler(IMapper mapper, IContractorInfoRepository ContractorInfoRepository,  IHttpContextAccessor httpContextAccessor) : base(httpContextAccessor)
        {
            _mapper = mapper;
            _ContractorInfoRepository = ContractorInfoRepository;
        }
    }
}