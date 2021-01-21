using ProjectManager.CMD.Domain.DomainObjects;
using ProjectManager.CMD.Domain.IRepositories;
using AutoMapper;using Microsoft.AspNetCore.Http;
using MediatR;
using Services.Common.DomainObjects;
using System.Threading;
using System.Threading.Tasks;

namespace  ProjectManager.CMD.Api.Application.Commands
{
    public class CreateNotifyAccountCommandHandler : NotifyAccountCommandHandler, IRequestHandler<CreateNotifyAccountCommand, MethodResult<CreateNotifyAccountCommandResponse>>
    {
        public CreateNotifyAccountCommandHandler(IMapper mapper, INotifyAccountRepository notifyAccountRepository, IHttpContextAccessor httpContextAccessor) : base(mapper, notifyAccountRepository, httpContextAccessor)
        {
        }

        /// <summary>
        /// Handle for creating a new NotifyAccount
        /// </summary>
        /// <param name="request"></param>
        /// <param name="cancellationToken"></param>
        /// <returns></returns>
        public async Task<MethodResult<CreateNotifyAccountCommandResponse>> Handle(CreateNotifyAccountCommand request, CancellationToken cancellationToken)
        {
            var methodResult = new MethodResult<CreateNotifyAccountCommandResponse>();
            var newNotifyAccount = new NotifyAccount(request.AccountId,request.GroupId,request.NotifyId,request.PushTime);
            newNotifyAccount.SetCreate(_user);
            newNotifyAccount.Status = request.Status.HasValue ? request.Status : newNotifyAccount.Status;
            newNotifyAccount.IsActive = request.IsActive.HasValue ? request.IsActive : newNotifyAccount.IsActive;
            newNotifyAccount.IsVisible = request.IsVisible.HasValue ? request.IsVisible : newNotifyAccount.IsVisible;
            await _notifyAccountRepository.AddAsync(newNotifyAccount).ConfigureAwait(false);
            await _notifyAccountRepository.UnitOfWork.SaveChangesAsync(cancellationToken).ConfigureAwait(false);
            methodResult.Result = _mapper.Map<CreateNotifyAccountCommandResponse>(newNotifyAccount);
            return methodResult;
        }
    }
}
