using Acc.Cmd.Domain;
using Acc.Cmd.Domain.Repositories;
using AutoMapper;using Microsoft.AspNetCore.Http;
using MediatR;
using Services.Common.DomainObjects;
using Services.Common.DomainObjects.Exceptions;
using Services.Common.Utilities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;

namespace  Acc.Cmd.Api.Application.Commands
{
    public class DeleteGroupFunctionCommandHandler : GroupFunctionCommandHandler, IRequestHandler<DeleteGroupFunctionCommand, MethodResult<DeleteGroupFunctionCommandResponse>>
    {
        public DeleteGroupFunctionCommandHandler(IMapper mapper, IGroupFunctionRepository GroupFunctionRepository,IHttpContextAccessor httpContextAccessor) : base(mapper, httpContextAccessor, GroupFunctionRepository)
        {
        }

        /// <summary>
        /// Handle for deleting a existing GroupFunction.
        /// </summary>
        /// <param name="request"></param>
        /// <param name="cancellationToken"></param>
        /// <returns></returns>
        public async Task<MethodResult<DeleteGroupFunctionCommandResponse>> Handle(DeleteGroupFunctionCommand request, CancellationToken cancellationToken)
        {
            var methodResult = new MethodResult<DeleteGroupFunctionCommandResponse>();
            var existingGroupFunctions = await _GroupFunctionRepository.GetAllListAsync(x => request.Ids.Contains(x.Id) && x.IsDelete == false).ConfigureAwait(false);
            if (existingGroupFunctions == null || !existingGroupFunctions.Any())
            {
                methodResult.AddAPIErrorMessage(nameof(ErrorCodeDelete.DErr001), new[]
                {
                    ErrorHelpers.GenerateErrorResult(nameof(request.Ids),string.Join(',',request.Ids))
                });
            }
            if (!methodResult.IsOk) throw new CommandHandlerException(methodResult.ErrorMessages);

            DateTime utc = DateTime.UtcNow;
            DateTime now = DateTime.Now;
            foreach (var existingGroupFunction in existingGroupFunctions)
            {
                existingGroupFunction.UpdateDate = now;
                existingGroupFunction.UpdateDateUTC = utc;
                existingGroupFunction.IsDelete = true;
                existingGroupFunction.SetUpdate(_user, null);

            }
            _GroupFunctionRepository.UpdateRange(existingGroupFunctions);
            await _GroupFunctionRepository.UnitOfWork.SaveChangesAsync(cancellationToken).ConfigureAwait(false);
            var GroupFunctionResponseDTOs = _mapper.Map<List<GroupFunctionCommandResponseDTO>>(existingGroupFunctions);
            methodResult.Result = new DeleteGroupFunctionCommandResponse(GroupFunctionResponseDTOs);
            return methodResult;
        }
    }
}