using Acc.Cmd.Domain;
using Acc.Cmd.Domain.Repositories;
using AutoMapper;
using MediatR;
using Services.Common.DomainObjects;
using Services.Common.DomainObjects.Exceptions;
using Services.Common.Utilities;
using System;
using System.Threading;
using System.Threading.Tasks;

namespace  Acc.Cmd.Api.Application.Commands
{
    public class UpdateAccountsCommandHandler : AccountsCommandHandler,IRequestHandler<UpdateAccountsCommand, MethodResult<UpdateAccountsCommandResponse>>
    {
        public UpdateAccountsCommandHandler(IMapper mapper, IAccountsRepository accountRepository) : base(mapper, accountRepository)
        {
        }

        /// <summary>
        /// Handle for update a existing Accounts.
        /// </summary>
        /// <param name="request"></param>
        /// <param name="cancellationToken"></param>
        /// <returns></returns>
        public async Task<MethodResult<UpdateAccountsCommandResponse>> Handle(UpdateAccountsCommand request, CancellationToken cancellationToken)
        {
            var methodResult = new MethodResult<UpdateAccountsCommandResponse>();
            var existingAccounts = await _accountsRepository.SingleOrDefaultAsync(x => x.Id == request.Id && x.IsDelete == false).ConfigureAwait(false);
            if (existingAccounts == null)
            {
                methodResult.AddAPIErrorMessage(nameof(ErrorCodeUpdate.UErr01), new[]
                {
                    ErrorHelpers.GenerateErrorResult(nameof(request.Id),request.Id)
                });
            }
            if (!methodResult.IsOk) throw new CommandHandlerException(methodResult.ErrorMessages);
            existingAccounts.IsActive = request.IsActive.HasValue ? request.IsActive : existingAccounts.IsActive;
            existingAccounts.IsVisible = request.IsActive.HasValue ? request.IsVisible : existingAccounts.IsVisible;
            existingAccounts.Status = request.Status.HasValue ? request.Status : existingAccounts.Status;
            existingAccounts.SetCode(request.Code);
            existingAccounts.SetType(request.Type);
            existingAccounts.SetAccountName(request.AccountName);
            existingAccounts.SetPasswordHash(request.Password);
            existingAccounts.SetUserId(request.UserId);
            existingAccounts.SetUpdate(0,0);
            _accountsRepository.Update(existingAccounts);
            await _accountsRepository.UnitOfWork.SaveChangesAsync(cancellationToken).ConfigureAwait(false);
            methodResult.Result = _mapper.Map<UpdateAccountsCommandResponse>(existingAccounts);
            return methodResult;
        }
    }
}