using Acc.Cmd.Domain.Repositories;
using AutoMapper;

namespace Acc.Cmd.Api.Application.Commands
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