using Acc.Cmd.Domain.DomainObjects;
using Acc.Cmd.Domain.Repositories;
using AutoMapper;
using MediatR;
using Services.Common.DomainObjects;
using System.Threading;
using System.Threading.Tasks;

namespace  Acc.Cmd.Api.Application.Commands
{
    public class CreateActionsCommandHandler : ActionsCommandHandler, IRequestHandler<CreateActionsCommand, MethodResult<CreateActionsCommandResponse>>
    {
        public CreateActionsCommandHandler(IMapper mapper, IActionsRepository ActionsRepository) : base(mapper, ActionsRepository)
        {
        }

        /// <summary>
        /// Handle for creating a new Actions
        /// </summary>
        /// <param name="request"></param>
        /// <param name="cancellationToken"></param>
        /// <returns></returns>
        public async Task<MethodResult<CreateActionsCommandResponse>> Handle(CreateActionsCommand request, CancellationToken cancellationToken)
        {
            var methodResult = new MethodResult<CreateActionsCommandResponse>();
            var newActions = new Actions(request.ParentId,
                                        request.Title,
                                        request.Descriptions,
                                        request.Icon,
                                        request.Url,
                                        request.CategoryId,
                                        request.Level);
            newActions.Status = request.Status.HasValue ? request.Status : newActions.Status;
            newActions.IsActive = request.IsActive.HasValue ? request.IsActive : newActions.IsActive;
            newActions.IsVisible = request.IsActive.HasValue ? request.IsVisible : newActions.IsVisible;
            await _actionsRepository.AddAsync(newActions).ConfigureAwait(false);
            await _actionsRepository.UnitOfWork.SaveChangesAsync(cancellationToken).ConfigureAwait(false);
            methodResult.Result = _mapper.Map<CreateActionsCommandResponse>(newActions);
            return methodResult;
        }
    }
}