﻿using Acc.Cmd.Domain.DomainObjects;
using Acc.Cmd.Domain.Repositories;
using AutoMapper;
using MediatR;
using Services.Common.DomainObjects;
using System.Threading;
using System.Threading.Tasks;

namespace  Acc.Cmd.Api.Application.Commands
{
    public class CreateGroupAccountCommandHandler : GroupAccountCommandHandler, IRequestHandler<CreateGroupAccountCommand, MethodResult<CreateGroupAccountCommandResponse>>
    {
        public CreateGroupAccountCommandHandler(IMapper mapper, IGroupAccountRepository GroupAccountRepository) : base(mapper, GroupAccountRepository)
        {
        }

        /// <summary>
        /// Handle for creating a new GroupAccount
        /// </summary>
        /// <param name="request"></param>
        /// <param name="cancellationToken"></param>
        /// <returns></returns>
        public async Task<MethodResult<CreateGroupAccountCommandResponse>> Handle(CreateGroupAccountCommand request, CancellationToken cancellationToken)
        {
            var methodResult = new MethodResult<CreateGroupAccountCommandResponse>();
            var newGroupAccount = new GroupAccount(request.AccountId,
                                                    request.GroupId);
            newGroupAccount.Status = request.Status.HasValue ? request.Status : newGroupAccount.Status;
            newGroupAccount.IsActive = request.IsActive.HasValue ? request.IsActive : newGroupAccount.IsActive;
            newGroupAccount.IsVisible = request.IsActive.HasValue ? request.IsVisible : newGroupAccount.IsVisible;
            await _GroupAccountRepository.AddAsync(newGroupAccount).ConfigureAwait(false);
            await _GroupAccountRepository.UnitOfWork.SaveChangesAsync(cancellationToken).ConfigureAwait(false);
            methodResult.Result = _mapper.Map<CreateGroupAccountCommandResponse>(newGroupAccount);
            return methodResult;
        }
    }
}