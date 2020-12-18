using Acc.Cmd.Domain.DomainObjects;
using Acc.Cmd.Domain.Repositories;
using AutoMapper;using Microsoft.AspNetCore.Http;
using MediatR;
using Services.Common.DomainObjects;
using System.Threading;
using System.Threading.Tasks;

namespace  Acc.Cmd.Api.Application.Commands
{
    public class CreateGroupAccountCommandHandler : GroupAccountCommandHandler, IRequestHandler<CreateGroupAccountCommand, MethodResult<CreateGroupAccountCommandResponse>>
    {
        public CreateGroupAccountCommandHandler(IMapper mapper, IGroupAccountRepository GroupAccountRepository,IHttpContextAccessor httpContextAccessor) : base(mapper, httpContextAccessor, GroupAccountRepository)
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
            newGroupAccount.SetCreate(_user);
            newGroupAccount.Status = request.Status.HasValue ? request.Status : newGroupAccount.Status;
            newGroupAccount.IsActive = request.IsActive.HasValue ? request.IsActive : newGroupAccount.IsActive;
            newGroupAccount.IsVisible = request.IsVisible.HasValue ? request.IsVisible : newGroupAccount.IsVisible;
            await _GroupAccountRepository.AddAsync(newGroupAccount).ConfigureAwait(false);
            await _GroupAccountRepository.UnitOfWork.SaveChangesAsync(cancellationToken).ConfigureAwait(false);
            methodResult.Result = _mapper.Map<CreateGroupAccountCommandResponse>(newGroupAccount);
            return methodResult;
        }
    }
}