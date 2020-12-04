using ProjectManager.CMD.Domain;
using ProjectManager.CMD.Domain.IRepositories;
using AutoMapper;
using Microsoft.AspNetCore.Http;
using MediatR;
using Services.Common.DomainObjects;
using Services.Common.DomainObjects.Exceptions;
using Services.Common.Utilities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;

namespace  ProjectManager.CMD.Api.Application.Commands
{
    public class DeleteNS_HopDongCommandHandler : NS_HopDongCommandHandler, IRequestHandler<DeleteNS_HopDongCommand, MethodResult<DeleteNS_HopDongCommandResponse>>
    {
        public DeleteNS_HopDongCommandHandler(IMapper mapper, INS_HopDongRepository NS_HopDongRepository,IHttpContextAccessor httpContextAccessor) : base(mapper, NS_HopDongRepository,httpContextAccessor)
        {
        }

        /// <summary>
        /// Handle for deleting a existing NS_HopDong.
        /// </summary>
        /// <param name="request"></param>
        /// <param name="cancellationToken"></param>
        /// <returns></returns>
        public async Task<MethodResult<DeleteNS_HopDongCommandResponse>> Handle(DeleteNS_HopDongCommand request, CancellationToken cancellationToken)
        {
            var methodResult = new MethodResult<DeleteNS_HopDongCommandResponse>();
            var existingNS_HopDong = await _NS_HopDongRepository.GetAllListAsync(x => request.Ids.Contains(x.Id) && x.IsDelete == false).ConfigureAwait(false);
            if (existingNS_HopDong == null || !existingNS_HopDong.Any())
            {
                methodResult.AddAPIErrorMessage(nameof(ErrorCodeDelete.DErr001), new[]
                {
                    ErrorHelpers.GenerateErrorResult(nameof(request.Ids),string.Join(',',request.Ids))
                });
            }
            if (!methodResult.IsOk) throw new CommandHandlerException(methodResult.ErrorMessages);

            DateTime utc = DateTime.UtcNow;
            DateTime now = DateTime.Now;
            foreach (var existingAssignment in existingNS_HopDong)
            {
                existingAssignment.UpdateDate = now;
                existingAssignment.UpdateDateUTC = utc;
                existingAssignment.IsDelete = true;
                existingAssignment.ModifyBy = 0;
                existingAssignment.SetUpdate(_user,0);
            }
            _NS_HopDongRepository.UpdateRange(existingNS_HopDong);
            await _NS_HopDongRepository.UnitOfWork.SaveChangesAsync(cancellationToken).ConfigureAwait(false);
            var NS_HopDongResponseDTOs = _mapper.Map<List<NS_HopDongCommandResponseDTO>>(existingNS_HopDong);
            methodResult.Result = new DeleteNS_HopDongCommandResponse(NS_HopDongResponseDTOs);
            return methodResult;
        }
    }
}