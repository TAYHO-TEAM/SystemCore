using Acc.Cmd.Domain.DomainObjects;
using Acc.Cmd.Domain.Repositories;
using AutoMapper;using Microsoft.AspNetCore.Http;
using MediatR;
using Services.Common.DomainObjects;
using System.Threading;
using System.Threading.Tasks;

namespace  Acc.Cmd.Api.Application.Commands
{
    public class CreateAccountsCommandHandler : AccountsCommandHandler, IRequestHandler<CreateAccountsCommand, MethodResult<CreateAccountsCommandResponse>>
    {
        public CreateAccountsCommandHandler(IMapper mapper, IAccountsRepository AccountsRepository,IHttpContextAccessor httpContextAccessor) : base(mapper, httpContextAccessor, AccountsRepository)
        {
        }

        /// <summary>
        /// Handle for creating a new Accounts
        /// </summary>
        /// <param name="request"></param>
        /// <param name="cancellationToken"></param>
        /// <returns></returns>
        public async Task<MethodResult<CreateAccountsCommandResponse>> Handle(CreateAccountsCommand request, CancellationToken cancellationToken)
        {
            var methodResult = new MethodResult<CreateAccountsCommandResponse>();
            var newAccounts = new Accounts(request.Code,
                                            request.Type,
                                            request.AccountName,
                                            request.Password,
                                            "",
                                            null,
                                            null,
                                            null,
                                            request.UserId);
            newAccounts.SetCreate(_user);
            newAccounts.Status = request.Status.HasValue ? request.Status : newAccounts.Status;
            newAccounts.IsActive = request.IsActive.HasValue ? request.IsActive : newAccounts.IsActive;
            newAccounts.IsVisible = request.IsActive.HasValue ? request.IsVisible : newAccounts.IsVisible;
            await _accountsRepository.AddAsync(newAccounts).ConfigureAwait(false);
            await _accountsRepository.UnitOfWork.SaveChangesAsync(cancellationToken).ConfigureAwait(false);
            methodResult.Result = _mapper.Map<CreateAccountsCommandResponse>(newAccounts);
            return methodResult;
        }
    }
}