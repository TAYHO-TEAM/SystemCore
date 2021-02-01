using ProjectManager.CMD.Domain.DomainObjects;
using ProjectManager.CMD.Domain.IRepositories;
using AutoMapper;using Microsoft.AspNetCore.Http;
using MediatR;
using Services.Common.DomainObjects;
using System.Threading;
using System.Threading.Tasks;

namespace  ProjectManager.CMD.Api.Application.Commands
{
    public class CreatePlanReportCommandHandler : PlanReportCommandHandler, IRequestHandler<CreatePlanReportCommand, MethodResult<CreatePlanReportCommandResponse>>
    {
        public CreatePlanReportCommandHandler(IMapper mapper,IHttpContextAccessor httpContextAccessor,IPlanReportRepository planReportRepository) : base(mapper, httpContextAccessor, planReportRepository)
        {
        }

        /// <summary>
        /// Handle for creating a new PlanReport
        /// </summary>
        /// <param name="request"></param>
        /// <param name="cancellationToken"></param>
        /// <returns></returns>
        public async Task<MethodResult<CreatePlanReportCommandResponse>> Handle(CreatePlanReportCommand request, CancellationToken cancellationToken)
        {
            var methodResult = new MethodResult<CreatePlanReportCommandResponse>();
            var newPlanReport = new PlanReport(request.PlanMasterId,request.PlanJobId,request.Content,request.Unit,request.Amount);
            newPlanReport.SetCreate(_user);
            newPlanReport.Status = request.Status.HasValue ? request.Status : newPlanReport.Status;
            newPlanReport.IsActive = request.IsActive.HasValue ? request.IsActive : true;
            newPlanReport.IsVisible = request.IsVisible.HasValue ? request.IsVisible : true;
            await _planReportRepository.AddAsync(newPlanReport).ConfigureAwait(false);
            await _planReportRepository.UnitOfWork.SaveChangesAsync(cancellationToken).ConfigureAwait(false);
            methodResult.Result = _mapper.Map<CreatePlanReportCommandResponse>(newPlanReport);
            return methodResult;
        }
    }
}
