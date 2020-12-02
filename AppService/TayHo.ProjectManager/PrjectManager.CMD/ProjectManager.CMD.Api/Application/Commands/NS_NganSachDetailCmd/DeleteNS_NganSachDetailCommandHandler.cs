using ProjectManager.CMD.Domain;
using ProjectManager.CMD.Domain.IRepositories;
using AutoMapper;
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
    public class DeleteNS_NganSachDetailCommandHandler : NS_NganSachDetailCommandHandler, IRequestHandler<DeleteNS_NganSachDetailCommand, MethodResult<DeleteNS_NganSachDetailCommandResponse>>
    {
        public DeleteNS_NganSachDetailCommandHandler(IMapper mapper, INS_NganSachDetailRepository NS_NganSachDetailRepository) : base(mapper, NS_NganSachDetailRepository)
        {
        }

        /// <summary>
        /// Handle for deleting a existing NS_NganSachDetail.
        /// </summary>
        /// <param name="request"></param>
        /// <param name="cancellationToken"></param>
        /// <returns></returns>
        public async Task<MethodResult<DeleteNS_NganSachDetailCommandResponse>> Handle(DeleteNS_NganSachDetailCommand request, CancellationToken cancellationToken)
        {
            var methodResult = new MethodResult<DeleteNS_NganSachDetailCommandResponse>();
            var existingNS_NganSachDetail = await _NS_NganSachDetailRepository.GetAllListAsync(x => request.Ids.Contains(x.Id) && x.IsDelete == false).ConfigureAwait(false);
            if (existingNS_NganSachDetail == null || !existingNS_NganSachDetail.Any())
            {
                methodResult.AddAPIErrorMessage(nameof(ErrorCodeDelete.DErr001), new[]
                {
                    ErrorHelpers.GenerateErrorResult(nameof(request.Ids),string.Join(',',request.Ids))
                });
            }
            if (!methodResult.IsOk) throw new CommandHandlerException(methodResult.ErrorMessages);

            DateTime utc = DateTime.UtcNow;
            DateTime now = DateTime.Now;
            foreach (var existingAssignment in existingNS_NganSachDetail)
            {
                existingAssignment.UpdateDate = now;
                existingAssignment.UpdateDateUTC = utc;
                existingAssignment.IsDelete = true;
                existingAssignment.ModifyBy = 0;
                existingAssignment.SetUpdate(0,0);
            }
            _NS_NganSachDetailRepository.UpdateRange(existingNS_NganSachDetail);
            await _NS_NganSachDetailRepository.UnitOfWork.SaveChangesAsync(cancellationToken).ConfigureAwait(false);
            var NS_NganSachDetailResponseDTOs = _mapper.Map<List<NS_NganSachDetailCommandResponseDTO>>(existingNS_NganSachDetail);
            methodResult.Result = new DeleteNS_NganSachDetailCommandResponse(NS_NganSachDetailResponseDTOs);
            return methodResult;
        }
    }
}