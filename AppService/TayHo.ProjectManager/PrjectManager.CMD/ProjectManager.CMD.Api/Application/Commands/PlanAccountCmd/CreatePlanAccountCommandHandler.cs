using ProjectManager.CMD.Domain.DomainObjects;
using ProjectManager.CMD.Domain.IRepositories;
using AutoMapper;using Microsoft.AspNetCore.Http;
using MediatR;
using Services.Common.DomainObjects;
using System.Threading;
using System.Threading.Tasks;

namespace  ProjectManager.CMD.Api.Application.Commands
{
    public class CreatePlanAccountCommandHandler : PlanAccountCommandHandler, IRequestHandler<CreatePlanAccountCommand, MethodResult<CreatePlanAccountCommandResponse>>
    {
        public CreatePlanAccountCommandHandler(IMapper mapper,IHttpContextAccessor httpContextAccessor,IPlanAccountRepository planAccountRepository) : base(mapper, httpContextAccessor, planAccountRepository)
        {
        }

        /// <summary>
        /// Handle for creating a new PlanAccount
        /// </summary>
        /// <param name="request"></param>
        /// <param name="cancellationToken"></param>
        /// <returns></returns>
        public async Task<MethodResult<CreatePlanAccountCommandResponse>> Handle(CreatePlanAccountCommand request, CancellationToken cancellationToken)
        {
            var methodResult = new MethodResult<CreatePlanAccountCommandResponse>();
            var newPlanAccount = new PlanAccount(request.AccountId,request.GroupId,request.PermistionId,request.OwnerById,request.OwnerTable);
            newPlanAccount.SetCreate(_user);
            newPlanAccount.Status = request.Status.HasValue ? request.Status : newPlanAccount.Status;
            newPlanAccount.IsActive = request.IsActive.HasValue ? request.IsActive : true;
            newPlanAccount.IsVisible = request.IsVisible.HasValue ? request.IsVisible : true;
            await _planAccountRepository.AddAsync(newPlanAccount).ConfigureAwait(false);
            await _planAccountRepository.UnitOfWork.SaveChangesAsync(cancellationToken).ConfigureAwait(false);
            methodResult.Result = _mapper.Map<CreatePlanAccountCommandResponse>(newPlanAccount);
            return methodResult;
        }
    }
}
