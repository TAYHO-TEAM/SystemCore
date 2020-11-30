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
    public class UpdateActionsCommandHandler : ActionsCommandHandler,IRequestHandler<UpdateActionsCommand, MethodResult<UpdateActionsCommandResponse>>
    {
        public UpdateActionsCommandHandler(IMapper mapper, IActionsRepository accountRepository) : base(mapper, accountRepository)
        {
        }

        /// <summary>
        /// Handle for update a existing Actions.
        /// </summary>
        /// <param name="request"></param>
        /// <param name="cancellationToken"></param>
        /// <returns></returns>
        public async Task<MethodResult<UpdateActionsCommandResponse>> Handle(UpdateActionsCommand request, CancellationToken cancellationToken)
        {
            var methodResult = new MethodResult<UpdateActionsCommandResponse>();
            var existingActions = await _actionsRepository.SingleOrDefaultAsync(x => x.Id == request.Id && x.IsDelete == false).ConfigureAwait(false);
            if (existingActions == null)
            {
                methodResult.AddAPIErrorMessage(nameof(ErrorCodeUpdate.UErr01), new[]
                {
                    ErrorHelpers.GenerateErrorResult(nameof(request.Id),request.Id)
                });
            }
            if (!methodResult.IsOk) throw new CommandHandlerException(methodResult.ErrorMessages);
            existingActions.IsActive = request.IsActive.HasValue ? request.IsActive : existingActions.IsActive;
            existingActions.IsVisible = request.IsActive.HasValue ? request.IsVisible : existingActions.IsVisible;
            existingActions.Status = request.Status.HasValue ? request.Status : existingActions.Status;
            existingActions.SetParentId(request.ParentId);
            existingActions.SetTitle(request.Title);
            existingActions.SetDescriptions(request.Descriptions);
            existingActions.SetIcon(request.Icon);
            existingActions.SetUrl(request.Url);
            existingActions.SetCategoryId(request.CategoryId);
            existingActions.SetLevel(request.Level);
            existingActions.SetUpdate(0,0);
            _actionsRepository.Update(existingActions);
            await _actionsRepository.UnitOfWork.SaveChangesAsync(cancellationToken).ConfigureAwait(false);
            methodResult.Result = _mapper.Map<UpdateActionsCommandResponse>(existingActions);
            return methodResult;
        }
    }
}