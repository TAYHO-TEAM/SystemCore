using Acc.Cmd.Domain;
using Acc.Cmd.Domain.Repositories;
using AutoMapper;using Microsoft.AspNetCore.Http;
using MediatR;
using Services.Common.DomainObjects;
using Services.Common.DomainObjects.Exceptions;
using Services.Common.Utilities;
using System;
using System.Threading;
using System.Threading.Tasks;

namespace  Acc.Cmd.Api.Application.Commands
{
    public class UpdateGroupFunctionCommandHandler : GroupFunctionCommandHandler,IRequestHandler<UpdateGroupFunctionCommand, MethodResult<UpdateGroupFunctionCommandResponse>>
    {
        public UpdateGroupFunctionCommandHandler(IMapper mapper, IGroupFunctionRepository FunctionRepository,IHttpContextAccessor httpContextAccessor) : base(mapper, httpContextAccessor, FunctionRepository)
        {
        }

        /// <summary>
        /// Handle for update a existing GroupFunction.
        /// </summary>
        /// <param name="request"></param>
        /// <param name="cancellationToken"></param>
        /// <returns></returns>
        public async Task<MethodResult<UpdateGroupFunctionCommandResponse>> Handle(UpdateGroupFunctionCommand request, CancellationToken cancellationToken)
        {
            var methodResult = new MethodResult<UpdateGroupFunctionCommandResponse>();
            var existingGroupFunction = await _GroupFunctionRepository.SingleOrDefaultAsync(x => x.Id == request.Id && x.IsDelete == false).ConfigureAwait(false);
            if (existingGroupFunction == null)
            {
                methodResult.AddAPIErrorMessage(nameof(ErrorCodeUpdate.UErr01), new[]
                {
                    ErrorHelpers.GenerateErrorResult(nameof(request.Id),request.Id)
                });
            }
            if (!methodResult.IsOk) throw new CommandHandlerException(methodResult.ErrorMessages);
            existingGroupFunction.IsActive = request.IsActive.HasValue ? request.IsActive : existingGroupFunction.IsActive;
            existingGroupFunction.IsVisible = request.IsActive.HasValue ? request.IsVisible : existingGroupFunction.IsVisible;
            existingGroupFunction.Status = request.Status.HasValue ? request.Status : existingGroupFunction.Status;
            existingGroupFunction.SetFunctionId(request.FunctionId);
            existingGroupFunction.SetGroupId(request.GroupId);

            existingGroupFunction.SetUpdate(_user,null);
            _GroupFunctionRepository.Update(existingGroupFunction);
            await _GroupFunctionRepository.UnitOfWork.SaveChangesAsync(cancellationToken).ConfigureAwait(false);
            methodResult.Result = _mapper.Map<UpdateGroupFunctionCommandResponse>(existingGroupFunction);
            return methodResult;
        }
    }
}