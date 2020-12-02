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
    public class DeleteNS_LoaiThauCommandHandler : NS_LoaiThauCommandHandler, IRequestHandler<DeleteNS_LoaiThauCommand, MethodResult<DeleteNS_LoaiThauCommandResponse>>
    {
        public DeleteNS_LoaiThauCommandHandler(IMapper mapper, INS_LoaiThauRepository NS_LoaiThauRepository) : base(mapper, NS_LoaiThauRepository)
        {
        }

        /// <summary>
        /// Handle for deleting a existing NS_LoaiThau.
        /// </summary>
        /// <param name="request"></param>
        /// <param name="cancellationToken"></param>
        /// <returns></returns>
        public async Task<MethodResult<DeleteNS_LoaiThauCommandResponse>> Handle(DeleteNS_LoaiThauCommand request, CancellationToken cancellationToken)
        {
            var methodResult = new MethodResult<DeleteNS_LoaiThauCommandResponse>();
            var existingNS_LoaiThau = await _NS_LoaiThauRepository.GetAllListAsync(x => request.Ids.Contains(x.Id) && x.IsDelete == false).ConfigureAwait(false);
            if (existingNS_LoaiThau == null || !existingNS_LoaiThau.Any())
            {
                methodResult.AddAPIErrorMessage(nameof(ErrorCodeDelete.DErr001), new[]
                {
                    ErrorHelpers.GenerateErrorResult(nameof(request.Ids),string.Join(',',request.Ids))
                });
            }
            if (!methodResult.IsOk) throw new CommandHandlerException(methodResult.ErrorMessages);

            DateTime utc = DateTime.UtcNow;
            DateTime now = DateTime.Now;
            foreach (var existingAssignment in existingNS_LoaiThau)
            {
                existingAssignment.UpdateDate = now;
                existingAssignment.UpdateDateUTC = utc;
                existingAssignment.IsDelete = true;
                existingAssignment.ModifyBy = 0;
                existingAssignment.SetUpdate(0,0);
            }
            _NS_LoaiThauRepository.UpdateRange(existingNS_LoaiThau);
            await _NS_LoaiThauRepository.UnitOfWork.SaveChangesAsync(cancellationToken).ConfigureAwait(false);
            var NS_LoaiThauResponseDTOs = _mapper.Map<List<NS_LoaiThauCommandResponseDTO>>(existingNS_LoaiThau);
            methodResult.Result = new DeleteNS_LoaiThauCommandResponse(NS_LoaiThauResponseDTOs);
            return methodResult;
        }
    }
}