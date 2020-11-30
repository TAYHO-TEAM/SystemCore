using Acc.Cmd.Domain.Repositories;
using AutoMapper;

namespace Acc.Cmd.Api.Application.Commands
{
    public class AccountsCommandHandler
    {
        protected readonly IMapper _mapper;
        protected readonly IAccountsRepository _accountsRepository;

        public AccountsCommandHandler(IMapper mapper, IAccountsRepository AccountsRepository)
        {
            _mapper = mapper;
            _accountsRepository = AccountsRepository;
        }
    }
}