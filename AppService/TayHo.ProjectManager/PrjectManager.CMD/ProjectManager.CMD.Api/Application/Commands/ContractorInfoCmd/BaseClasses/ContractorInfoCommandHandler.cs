using ProjectManager.CMD.Domain.IRepositories;
using AutoMapper;

namespace ProjectManager.CMD.Api.Application.Commands
{
    public class ContractorInfoCommandHandler
    {
        protected readonly IMapper _mapper;
        protected readonly IContractorInfoRepository _ContractorInfoRepository;

        public ContractorInfoCommandHandler(IMapper mapper, IContractorInfoRepository ContractorInfoRepository)
        {
            _mapper = mapper;
            _ContractorInfoRepository = ContractorInfoRepository;
        }
    }
}